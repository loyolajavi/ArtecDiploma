SELECT Cat.DescripCategoria, SolDet.Cantidad
FROM SolicDetalle SolDet
INNER JOIN Categoria Cat
ON SolDet.IdCategoria = Cat.IdCategoria
INNER JOIN PartidaDetalle PDet
ON SolDet.IdSolicitud = PDet.IdSolicitud AND SolDet.IdSolicitudDetalle = PDet.IdSolicitudDetalle
INNER JOIN Partida Par
ON Par.IdPartida = PDet.IdPartida
WHERE Par.IdPartida = 56
AND SolDet.IdEstadoSolicDetalle != 2--Distinto de Finalizado


SELECT * from partida
WHERE Partida.idpartida = 56

select * from categoria

select cat.DescripCategoria, sdet.Cantidad, tipo.DescripTipoBien
from PartidaDetalle pdet
INNER JOIN SolicDetalle sdet
ON sdet.IdSolicitud = pdet.IdSolicitud and sdet.IdSolicitudDetalle = pdet.IdSolicitudDetalle
INNER JOIN Partida par
ON par.IdPartida = pdet.IdPartida
INNER JOIN Categoria cat
ON cat.IdCategoria = sdet.IdCategoria
Left JOIN Bien bi
ON bi.IdBien = cat.IdCategoria
INNER JOIN TipoBien tipo
ON tipo.IdTipoBien = bi.IdTipoBien
WHERE par.IdPartida = 56
AND sdet.IdEstadoSolicDetalle != 2--Distinto de Finalizado


select * from Bien

select pdet.IdPartidaDetalle, count(inv.IdInventario) as Comprado from Inventario inv
INNER JOIN PartidaDetalle pdet
ON inv.IdPartida = pdet.IdPartida and inv.IdPartidaDetalle = pdet.IdPartidaDetalle
WHERE pdet.IdPartida = 56
group by pdet.IdPartidaDetalle
