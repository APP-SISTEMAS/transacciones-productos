USE [Tienda]
GO

/****** Object:  StoredProcedure [dbo].[spInsertar_TransacionesProductos]    Script Date: 8/9/2025 1:10:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*
Nombre:				spGet_Deptos
Descripcion:		Inserta la informacion transaciones de los departamentos
Autor:				Emerson A.
Fecha Creacion:		08/09/2025
==============================================================
Detalles de Actualzaciones:
Actualizado por:	   xxxxxx
Fecha Actualizacion:   xxxxxx
Detalle Actualizacion: xxxxxx

==============================================================
*/

CREATE PROCEDURE [dbo].[spInsertar_TransacionesProductos]
@Id AS int,
@Fecha AS datetime,
@tipo as varchar(15),
@cantidad AS int,
@Observacion as varchar(50)
AS
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY

				INSERT INTO Tienda.dbo.Fact_DetalleTransacciones 
				(
					 IdProducto, Fecha, TipoTransaccion, Cantidad, Observacion 
				) VALUES
				(
					@Id,
					@Fecha,
				
					CASE WHEN @tipo = 'Entrada' THEN 'E' ELSE 'S' END, @cantidad, @Observacion

				)
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION;
		    DECLARE @msg NVARCHAR(4000) = ERROR_MESSAGE();
			RAISERROR(@msg, 16, 1);

		END CATCH

	END




GO


