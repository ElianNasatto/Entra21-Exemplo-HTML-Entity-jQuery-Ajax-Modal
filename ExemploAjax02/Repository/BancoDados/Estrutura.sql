CREATE TABLE pessoas(

id INT PRIMARY KEY IDENTITY(1,1),
NOME VARCHAR(100),
cpf VARCHAR(14),
registro_ativo BIT
);

INSERT INTO pessoas (nome,cpf,registro_ativo) VALUES
('LOLA','656.656.565-67',1),
('LALA','123.123.321-10',1);

SELECT * FROM pessoas;