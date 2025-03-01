
USE Gimnasio;

-- ********** CONSULTAS REFERENTES A CLIENTES

SELECT * FROM Cliente;

SELECT 
	CodigoCliente	[Codigo_Cliente],
	CodigoGimnasio	[Codigo_Gimnasio],
	PrimerNombre	[Primer_Nombre],
	SegundoNombre	[Segundo_Nombre],
	PrimerApellido	[Primer_Apellido],
	SegundoApellido	[Segundo_Apellido],
	ApellidoCasada	[Apellido_Casada]
FROM 
	Cliente;
--WHERE 
--	CodigoGimnasio LIKE '%%'
--	OR PRIMER_NOMBRE LIKE '%%'
	