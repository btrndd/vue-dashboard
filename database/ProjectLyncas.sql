--QUERY PARA CRIAR O DB E TABELAS
USE MASTER

DROP DATABASE IF EXISTS ProjectLyncas;

CREATE DATABASE ProjectLyncas;

USE ProjectLyncas;

CREATE TABLE pessoas(
    idPessoa INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    sobrenome VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    telefone VARCHAR(50) NOT NULL,
    dataNasc DATE NOT NULL
)

CREATE TABLE auths(
    id INT IDENTITY(1,1) PRIMARY KEY,
    idPessoa INT NOT NULL
    FOREIGN KEY REFERENCES pessoas(idPessoa)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
    senha VARCHAR(50) NOT NULL,
    status VARCHAR(50) NOT NULL    
)

INSERT INTO pessoas (nome, sobrenome, email, telefone, dataNasc)
VALUES
  ('Bruno', 'Trindade', 'bruno@mail.com', '27999009999', '1996-04-01'),
  ('Gabriela', 'Paganini', 'gabriel@mail.com', '27999779999', '1991-01-03');

INSERT INTO auths (idPessoa, senha, status)
VALUES
  (1, '123456', 'true'),
  (2, '123abc', 'true');


-- QUERY COM SELECT DEVOLVENDO TODOS OS USUÁRIOS ATIVOS
SELECT ps.nome AS usuario,
ps.email AS email,
au.status AS status
FROM pessoas AS ps
INNER JOIN auths AS au
ON ps.idPessoa = au.idPessoa
WHERE au.status = 'true';

-- QUERY DE UPDATE NA TABELA
UPDATE ProjectLyncas.dbo.auths
SET auths.status = 'false'
WHERE auths.idPessoa = 2;

-- QUERY DE DELETE NA TABELA
DELETE FROM ProjectLyncas.dbo.pessoas
WHERE pessoas.sobrenome = 'Trindade';
