DROP TABLE IF EXISTS produtos,vendas,pessoas;

select * from vendas;
INSERT INTO pessoas (nome,cpf,registro_ativo) VALUES
('LOLA','656.656.565-67',1),
('LALA','123.123.321-10',1);

INSERT INTO produtos(id_venda, quantidade,valor,registro_ativo, nome) VALUES
(1,20,29.99,1,'Mercede'),
(2,10,10.20,1,'Filhote de Jacare'),
(1,8001,12.3,1,'Pão de queijo');

select * from vendas;


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
		valor DECIMAL(8,2),
		registro_ativo BIT
);