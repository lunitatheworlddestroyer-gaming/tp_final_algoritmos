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
