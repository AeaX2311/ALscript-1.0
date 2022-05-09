USE alscript
GO

	-- Matriz ordenada por estados ascendentemente
	SELECT 
		M.*
	FROM (SELECT *, CONVERT(INT, Estado) AS Est FROM matriz) M
	ORDER BY M.Est ASC

	-- Obtener descripcion de error
	SELECT
		m2.FDC
	FROM matriz m
		INNER JOIN matriz m2 
			ON m2.Estado = m.Estado - 1
	WHERE m.cat = 'ERROR01'


	-- Auxiliares
	UPDATE
		matriz
		set [c=] = 186
	where Estado =184

	UPDATE
		matriz
		set [fdc] = 140
	where Estado in (2,3,4)

	select [C,] from matriz

	[