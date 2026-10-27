create database Trabajo_final;
use Trabajo_final; 


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

-- Tabla cartas
CREATE TABLE cartas (
    id int auto_increment primary key,
    foreign key (palo) references palos(nombre),
    numero int,
    valor int
);

-- Tabla palos
CREATE TABLE palos (
    id int auto_increment primary key,
    nombre varchar(50)
);

insert into palos(nombre) values
('espada'),
('oro'),
('basto'),
('copa');

insert into cartas (palo, numero, valor) values
('espada', 1, 13),
('espada', 2, 8),
('espada', 3, 9),
('espada', 4, 0),
('espada', 5, 1),
('espada', 6, 2),
('espada', 7, 11),
('espada', 10, 4),
('espada', 11, 5),
('espada', 12, 6),
('oro', 1, 7),
('oro', 2, 8),
('oro', 3, 9),
('oro', 4, 0),
('oro', 5, 1),
('oro', 6, 2),
('oro', 7, 10),
('oro', 10, 4),
('oro', 11, 5),
('oro', 12, 6),
('basto', 1, 12),
('basto', 2, 8),
('basto', 3, 9),
('basto', 4, 0),
('basto', 5, 1),
('basto', 6, 2),
('basto', 7, 3),
('basto', 10, 4),
('basto', 11, 5),
('basto', 12, 6),
('copa', 1, 7),
('copa', 2, 8),
('copa', 3, 9),
('copa', 4, 0),
('copa', 5, 1),
('copa', 6, 2),
('copa', 7, 3),
('copa', 10, 4),
('copa', 11, 5),
('copa', 12, 6);

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
    DECLARE v_palo VARCHAR(50);
    DECLARE v_numero INT;
    
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
    -- (Esta tabla se destruye automáticamente al terminar la ejecución)
    CREATE TEMPORARY TABLE IF NOT EXISTS mano_repartida (
        jugador_id INT,
        orden_carta INT,
        carta_id INT,
        palo VARCHAR(50),
        numero INT
    );
    
    -- Limpiar la tabla temporal por si acaso
    TRUNCATE TABLE mano_repartida;

    -- 3. Crear una tabla temporal con las cartas disponibles y desordenarlas (RAND)
    CREATE TEMPORARY TABLE cartas_disponibles AS
    SELECT id, palo, numero FROM cartas; -- Usa tu tabla de cartas

    -- 4. Bucle para repartir 3 cartas a cada jugador (repartiendo de a 1 carta por ronda)
    WHILE v_ronda_actual <= 3 DO
        SET v_jugador_actual = 1;
        
        WHILE v_jugador_actual <= v_total_jugadores DO
            
            -- Seleccionar una carta aleatoria de las disponibles
            SELECT id, palo, numero INTO v_id_carta, v_palo, v_numero
            FROM cartas_disponibles
            ORDER BY RAND()
            LIMIT 1;
            
            -- Asignarle la carta al jugador actual en la ronda correspondiente
            INSERT INTO mano_repartida (jugador_id, orden_carta, carta_id, palo, numero)
            VALUES (v_jugador_actual, v_ronda_actual, v_id_carta, v_palo, v_numero);
            
            -- Eliminar la carta seleccionada para que NUNCA se vuelva a repetir en esta mano
            DELETE FROM cartas_disponibles WHERE id = v_id_carta;
            
            -- Pasar al siguiente jugador
            SET v_jugador_actual = v_jugador_actual + 1;
        END WHILE;
        
        -- Pasar a la siguiente ronda de cartas
        SET v_ronda_actual = v_ronda_actual + 1;
    END WHILE;

    -- 5. Mostrar el resultado final del reparto para que tu aplicación lo lea
    SELECT * FROM mano_repartida ORDER BY jugador_id, orden_carta;

    -- 6. Limpieza de tablas temporales
    DROP TEMPORARY TABLE cartas_disponibles;
    DROP TEMPORARY TABLE mano_repartida;

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
-- Esta vista organiza las cartas 
-- ordenadas de mayor a menor valor según la jerarquía que ya definiste en el insert
CREATE VIEW vw_cartas_jerarquia AS
SELECT 
    id,
    palo,
    numero,
    valor
FROM cartas;

-- =======fin de las vistas=======
