create database Trabajo_final;
use Trabajo_final; 
	set sql_safe_updates = 0;

-- Tabla ususarios
CREATE TABLE usuarios (
    id int auto_increment primary key,
    nombre varchar(50),
    pass varchar(50),
    partidas_ganadas int default 0,
    partidas_perdidos int default 0,
    partidas_jugadas int default 0,
    torneos_ganados int default 0,
    torneos_jugados int default 0
);

-- Tabla palos
CREATE TABLE palos (
    id int auto_increment primary key,
    nombre varchar(50)
);

-- Tabla cartas
CREATE TABLE cartas (
    id int auto_increment primary key,
    palo int,
    numero int,
    valor_truco int,
    valor_envido int,
	foreign key (palo) references palos(id)
) engine=InnoDB;

insert into palos(nombre) values
('espada'),
('oro'),
('basto'),
('copa');

insert into cartas (palo, numero, valor_truco, valor_envido) values
('1', 1, 13, 1),
('1', 2, 8, 2),
('1', 3, 9, 3),
('1', 4, 0, 4),
('1', 5, 1, 5),
('1', 6, 2, 6),
('1', 7, 11, 7),
('1', 10, 4, 0),
('1', 11, 5, 0),
('1', 12, 6, 0),
('2', 1, 7, 1),
('2', 2, 8, 2),
('2', 3, 9, 3),
('2', 4, 0, 4),
('2', 5, 1, 5),
('2', 6, 2, 6),
('2', 7, 10, 7),
('2', 10, 4, 0),
('2', 11, 5, 0),
('2', 12, 6, 0),
('3', 1, 12, 1),
('3', 2, 8, 2),
('3', 3, 9, 3),
('3', 4, 0, 4),
('3', 5, 1, 5),
('3', 6, 2, 6),
('3', 7, 3, 7),
('3', 10, 4, 0),
('3', 11, 5, 0),
('3', 12, 6, 0),
('4', 1, 7, 1),
('4', 2, 8, 2),
('4', 3, 9, 3),
('4', 4, 0, 4),
('4', 5, 1, 5),
('4', 6, 2, 6),
('4', 7, 3, 7),
('4', 10, 4, 0),
('4', 11, 5, 0),
('4', 12, 6, 0);

insert into usuarios (nombre, pass) values
('test', '1234')

-- PROCEDIMIENTO ALMACENADO

DELIMITER //

CREATE PROCEDURE repartir_cartas_truco (
    IN p_modo_juego VARCHAR(10) -- Valores esperados: '1v1', '2v2', '3v3'
)
BEGIN

    DECLARE v_total_jugadores INT;
    DECLARE v_jugador_actual INT DEFAULT 1;
    DECLARE v_ronda_actual INT DEFAULT 1;
    DECLARE v_id_carta INT;
    DECLARE v_palo int;
    DECLARE v_numero INT;
    declare v_valor_truco int;
    declare v_valor_envido int;
    
    -- 1. Determinar la cantidad de jugadores según el modo
    IF p_modo_juego = '1v1' THEN
        SET v_total_jugadores = 2;
    ELSEIF p_modo_juego = '2v2' THEN
        SET v_total_jugadores = 4;
    ELSEIF p_modo_juego = '3v3' THEN
        SET v_total_jugadores = 6;
    ELSE
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Modo de juego inválido. Use 1v1, 2v2 o 3v3.';
    END IF;

    -- 2. Crear una tabla temporal para guardar el reparto de esta mano
    CREATE TEMPORARY TABLE IF NOT EXISTS mano_repartida (
        jugador_id INT,
        palo int,
        numero INT, 
        valor_truco int,
        valor_envido int
    );
    
    -- Limpiar la tabla temporal por si acaso
    TRUNCATE TABLE mano_repartida;

    -- 3. Crear una tabla temporal con las cartas disponibles y desordenarlas (RAND)
    CREATE TEMPORARY TABLE cartas_disponibles AS
    SELECT id, palo, numero, valor_truco, valor_envido FROM cartas; -- Usa tu tabla de cartas

    -- 4. Bucle para repartir 3 cartas a cada jugador (repartiendo de a 1 carta por ronda)
    WHILE v_ronda_actual <= 3 DO
        SET v_jugador_actual = 1;
        
        WHILE v_jugador_actual <= v_total_jugadores DO
            
            -- Seleccionar una carta aleatoria de las disponibles
            SELECT id, palo, numero, valor_truco, valor_envido INTO v_id_carta, v_palo, v_numero, v_valor_truco, v_valor_envido
            FROM cartas_disponibles
            ORDER BY RAND()
            LIMIT 1;
            
            -- Asignarle la carta al jugador actual en la ronda correspondiente
            INSERT INTO mano_repartida (jugador_id, palo, numero, valor_truco, valor_envido)
            VALUES (v_jugador_actual, v_palo, v_numero, v_valor_truco, v_valor_envido);
            
            -- Eliminar la carta seleccionada para que NUNCA se vuelva a repetir en esta mano
            DELETE FROM cartas_disponibles WHERE id = v_id_carta;
            
            -- Pasar al siguiente jugador
            SET v_jugador_actual = v_jugador_actual + 1;
        END WHILE;
        
        -- Pasar a la siguiente ronda de cartas
        SET v_ronda_actual = v_ronda_actual + 1;
    END WHILE;

    -- 5. Mostrar el resultado final del reparto para que tu aplicación lo lea
    SELECT * FROM mano_repartida ORDER BY jugador_id;

    -- 6. Limpieza de tablas temporales
    DROP TEMPORARY TABLE cartas_disponibles;

END //

DELIMITER ;


-- VISTAS
-- muestra la lista de jugadores ordenada por su rendimiento.
-- Además, calcula automáticamente el porcentaje de efectividad (victorias) 
-- en base a las partidas jugadas y ganadas
CREATE VIEW vw_ranking_usuarios AS
SELECT 
    id,
    nombre,
    partidas_jugadas,
    partidas_ganadas,
    partidas_perdidos,
    torneos_ganados,
    torneos_jugados,
    CASE 
        WHEN partidas_jugadas > 0 THEN ROUND((partidas_ganadas * 100.0) / partidas_jugadas, 2)
        ELSE 0 
    END AS porcentaje_efectividad
FROM usuarios;


-- =======fin de las vistas=======

