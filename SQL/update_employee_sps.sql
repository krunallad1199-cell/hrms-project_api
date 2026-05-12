-- Update sp_GetEmployees to include Email
ALTER PROCEDURE [dbo].[sp_GetEmployees]
AS
BEGIN
    SELECT 
        E.Id, 
        E.EmployeeCode, 
        E.FirstName, 
        E.LastName, 
        E.Email,
        D.Name AS Department,
        DS.Name AS Designation, 
        E.DeptId,
        E.DesigId,
        E.DateOfJoining, 
        E.IsActive
    FROM Employees E
    LEFT JOIN Departments D ON E.DeptId = D.Id
    LEFT JOIN Designations DS ON E.DesigId = DS.Id;
END;

GO

-- Update sp_UpsertEmployee to include Email
ALTER PROCEDURE [dbo].[sp_UpsertEmployee]
    @Id INT = 0,
    @EmployeeCode NVARCHAR(20),
    @FirstName NVARCHAR(50),
    @LastName NVARCHAR(50),
    @Email NVARCHAR(100) = NULL,
    @DeptId INT,
    @DesigId INT,
    @DateOfJoining DATETIME,
    @IsActive BIT
AS
BEGIN
    SET NOCOUNT ON;
    IF @Id = 0
    BEGIN
        INSERT INTO Employees (EmployeeCode, FirstName, LastName, Email, DeptId, DesigId, DateOfJoining, IsActive)
        VALUES (@EmployeeCode, @FirstName, @LastName, @Email, @DeptId, @DesigId, @DateOfJoining, @IsActive);
    END
    ELSE
    BEGIN
        UPDATE Employees
        SET EmployeeCode = @EmployeeCode,
            FirstName = @FirstName,
            LastName = @LastName,
            Email = @Email,
            DeptId = @DeptId,
            DesigId = @DesigId,
            DateOfJoining = @DateOfJoining,
            IsActive = @IsActive
        WHERE Id = @Id;
    END
END;

GO

-- Create or update sp_DeleteEmployee
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_DeleteEmployee')
    DROP PROCEDURE sp_DeleteEmployee;

GO

CREATE PROCEDURE [dbo].[sp_DeleteEmployee]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Employees WHERE Id = @Id;
END;

GO

-- Create sp_ArchiveEmployee (soft delete - sets IsActive = 0)
IF EXISTS (SELECT * FROM sys.procedures WHERE name = 'sp_ArchiveEmployee')
    DROP PROCEDURE sp_ArchiveEmployee;

GO

CREATE PROCEDURE [dbo].[sp_ArchiveEmployee]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Employees SET IsActive = 0 WHERE Id = @Id;
END;

GO
