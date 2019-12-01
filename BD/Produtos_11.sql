create database produtos_11;

use produtos_11;

create table produtos(
	id int unsigned auto_increment not null primary key,
    descricao varchar(50),
    valor double,
    quantidade int,
    dt datetime,
    imagem varchar(200)
);

create table usuarios (
	login varchar(80) not null primary key,
    senha varchar(80) not null
);

select * from usuarios;
select * from produtos;