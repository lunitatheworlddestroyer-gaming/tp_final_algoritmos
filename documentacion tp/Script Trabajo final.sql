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

create table log_usuarios(
	id int auto_increment primary key,
    id_usuario int,
    accion varchar(50),
    hora datetime,
    foreign key (id_usuario) references usuarios(id)
)engine=InnoDB;

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
('test', '1234');

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
ALTER TABLE usuarios ADD UNIQUE KEY uq_usuarios_nombre (nombre);

DELIMITER $$

CREATE PROCEDURE sp_registrar_usuario(
    IN p_nombre VARCHAR(50),
    IN p_pass VARCHAR(50)
)
BEGIN
    DECLARE v_existe INT DEFAULT 0;

    -- Protección extra si dos registros llegan al mismo tiempo
    DECLARE EXIT HANDLER FOR 1062
    BEGIN
        SELECT 'No se pudo registrar porque ya hay un usuario registrado con ese nombre' AS mensaje;
    END;

    SELECT COUNT(*) INTO v_existe
    FROM usuarios
    WHERE nombre = TRIM(p_nombre);

    IF v_existe > 0 THEN
        SELECT 'No se pudo registrar porque ya hay un usuario registrado con ese nombre' AS mensaje;
    ELSE
        INSERT INTO usuarios (nombre, pass)
        VALUES (TRIM(p_nombre), p_pass);

        SELECT 'Se pudo registrar correctamente, ahora vuelva a introducir su usuario y contraseña para empezar a jugar' AS mensaje;
    END IF;
END$$

create trigger after_insert_usuarios
after insert on usuarios
for each row
begin
	insert into log_usuarios(id_usuario, accion, hora)
    values(new.id, 'se registro el usuario', now());
end;