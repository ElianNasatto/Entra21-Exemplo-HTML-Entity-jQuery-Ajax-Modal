DROP TABLE IF EXISTS produtos,vendas,pessoas;

select * from vendas;
INSERT INTO pessoas (nome,cpf,registro_ativo) VALUES
('LOLA','656.656.565-67',1),
('LALA','123.123.321-10',1);

CREATE TABLE pessoas(
		id INT PRIMARY KEY IDENTITY(1,1),
		NOME VARCHAR(100),
		cpf VARCHAR(14),
		registro_ativo BIT
);


CREATE TABLE vendas(
		id INT PRIMARY KEY IDENTITY(1,1),
		id_cliente INT, FOREIGN KEY (id_cliente) REFERENCES pessoas(id),
		descricao TEXT,
		registro_ativo BIT
);

CREATE TABLE produtos(
		id INT PRIMARY KEY IDENTITY(1,1),
		id_venda INT,
		FOREIGN KEY(id_venda) REFERENCES vendas(id),
		nome VARCHAR(100),
		quantidade INT,
		valor DECIMAL(8,2)
);