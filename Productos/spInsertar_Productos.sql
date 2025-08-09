USE [Tienda]
GO

/****** Object:  StoredProcedure [dbo].[spInsertar_Productos]    Script Date: 8/9/2025 1:10:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
Nombre:				spGet_Deptos
Descripcion:		Inserta la informacion de los departamentos
Autor:				Emerson A.
Fecha Creacion:		08/09/2025
==============================================================
Detalles de Actualzaciones:
Actualizado por:	   xxxxxx
Fecha Actualizacion:   xxxxxx
Detalle Actualizacion: xxxxxx

==============================================================
*/

CREATE PROCEDURE [dbo].[spInsertar_Productos]
@Codigo AS VARCHAR(15),
@Descripcion AS VARCHAR(50),
@Cantidad INT,
@Estado AS Varchar(15)
AS
	BEGIN
		BEGIN TRANSACTION
		BEGIN TRY

				INSERT INTO Tienda.dbo.Fact_Productos 
				(
					Codigo, Descripcion, Cantidad, Estado  
				) VALUES
				(
					@Codigo,
					@Descripcion,
					@Cantidad,
					CASE WHEN @Estado = 'Activo' THEN 1 ELSE 0 END
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


