create database Trabajo_final;
use Trabajo_final; 


-- Tabla ususarios
CREATE TABLE usuarios (
    id int auto_increment primary key,
    nombre varchar(50),
    pass varchar(50),
    partidas_ganadas int,
    partidas_perdidos int,
    partidas_jugadas int,
    torneos_ganados int,
    torneos_jugados int
);

-- Tabla cartas
CREATE TABLE cartas (
    id int auto_increment primary key,
    nombre varchar(50),
    palo varchar(50),
    numero int,
    valor int
);

-- Tabla palos
CREATE TABLE palos (
    id int auto_increment primary key,
    nombre varchar(50)
);
