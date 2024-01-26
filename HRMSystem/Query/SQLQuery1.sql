USE master; 

IF EXISTS (
	SELECT * 
	FROM sys.databases 
	WHERE name = N'HRMSystem'
) BEGIN 
	DROP DATABASE HRMSystem; 
END; 
CREATE DATABASE HRMSystem; 

USE HRMSystem; 
SET DATEFORMAT DMY; 

CREATE TABLE InsuranceTypes (
	IdInsType SMALLINT NOT NULL PRIMARY KEY, 
	NameInsType NVARCHAR(25) NOT NULL, 
	PayPercent FLOAT NOT NULL
);
INSERT INTO InsuranceTypes VALUES 
	(1, N'Bảo hiểm Y tế', 4.5), 
	(2, N'Bảo hiểm Tai nạn', 2), 
	(3, N'Hưu trí', 14);
CREATE TABLE WorkTypes (
	IdWorkType SMALLINT NOT NULL PRIMARY KEY, 
	NameWorkType NVARCHAR(40) NOT NULL, 
	Bonus FLOAT NOT NULL 
);
CREATE TABLE EmployeeTypes (
	IdType SMALLINT NOT NULL PRIMARY KEY, 
	NameType NVARCHAR(25) NOT NULL
);
CREATE TABLE PositionTypes (
	IdPosition SMALLINT NOT NULL PRIMARY KEY, 
	NamePosition NVARCHAR(40) NOT NULL, 
	BaseSalary FLOAT NOT NULL, 
	IdWorkType SMALLINT NOT NULL 
		FOREIGN KEY REFERENCES WorkTypes(IdWorkType),
	IdEmployeeTypes SMALLINT 
		FOREIGN KEY REFERENCES EmployeeTypes(IdType)
);
INSERT INTO WorkTypes VALUES
	(1, N'Công việc nặng nhọc', 50000), 
	(2, N'Công việc văn phòng', 0); 
INSERT INTO EmployeeTypes VALUES 
	(1, N'Cơ hữu'), 
	(2, N'Part-time');
INSERT INTO PositionTypes VALUES 
	(1, N'Giám đốc', 754000, 2, 1), 
	(2, N'Trưởng phòng', 549000, 2, 1), 
	(3, N'Nhân viên văn phòng', 465000, 1, 1), 
	(4, N'Nhân viên văn phòng', 35000, 1, 2), 
	(5, N'Công nhân', 271000, 1, 1), 
	(6, N'Công nhân', 22000, 1, 2), 
	(7, N'Lao công', 165000, 1, 1), 
	(8, N'Lao công', 16000, 1, 2);
CREATE TABLE EducationTypes (
	IdEduType SMALLINT NOT NULL PRIMARY KEY, 
	NameEduType NVARCHAR(25) NOT NULL, 
	Bonus FLOAT NOT NULL 
);
CREATE TABLE EmployeeStates (
	IdState SMALLINT NOT NULL PRIMARY KEY, 
	NameState NVARCHAR(25) NOT NULL
);
INSERT INTO EducationTypes VALUES 
	(0, N'Phổ thông', 0), 
	(1, N'Cao đẳng - Đại học', 160000), 
	(2, N'Cao học', 740000);
INSERT INTO EmployeeStates VALUES 
	(1, N'Đang làm'), 
	(2, N'Nghỉ việc'), 
	(3, N'Đang chờ duyệt');
CREATE TABLE Employees (
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
	Name NVARCHAR(50) NOT NULL,
	Dob DATETIME NOT NULL,
	Address NVARCHAR(50) NOT NULL, 
	Phone CHAR(10) NOT NULL, 
	IdPosition SMALLINT NOT NULL 
		FOREIGN KEY REFERENCES PositionTypes(IdPosition), 
	IdEduType SMALLINT NOT NULL 
		FOREIGN KEY REFERENCES EducationTypes(IdEduType),
	IdState SMALLINT NOT NULL 
		FOREIGN KEY REFERENCES EmployeeStates(IdState)
);
CREATE TABLE WorkLogs (
	Id INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, 
	EmployeeId INT NOT NULL, 
	CheckinTime DATETIME NOT NULL,
	CheckoutTime DATETIME, 
	FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);
CREATE TABLE AbsentTypes (
	IdAbsentType SMALLINT NOT NULL PRIMARY KEY, 
	NameAbsentType NVARCHAR(25) NOT NULL, 
);
INSERT INTO AbsentTypes VALUES 
	(0, N'Không phép'), 
	(1, N'Có phép');
CREATE TABLE AbsentLogs (
	IdAbsentType SMALLINT NOT NULL, 
	Id INT NOT NULL, 
	Reason NVARCHAR(100),
	PRIMARY KEY (IdAbsentType, Id), 
	FOREIGN KEY (IdAbsentType) REFERENCES AbsentTypes(IdAbsentType), 
	FOREIGN KEY (Id) REFERENCES Employees(Id)
);
CREATE TABLE SalaryLogs (
	IdLog CHAR(6) NOT NULL PRIMARY KEY, 
	Id INT NOT NULL FOREIGN KEY REFERENCES Employees(Id), 
	TotalSalary FLOAT NOT NULL, 
	PaidDate DATETIME NOT NULL, 
	Note NVARCHAR(100) 
);

-- In case of emergency :)
-- Remember to export Diagram for ez :D

SELECT * FROM InsuranceTypes; -- x
SELECT * FROM WorkTypes; -- x
SELECT * FROM EmployeeTypes; -- x
SELECT * FROM PositionTypes; -- x
SELECT * FROM EmployeeStates; -- x
SELECT * FROM EducationTypes; -- x
SELECT * FROM Employees; -- x
SELECT * FROM WorkLogs; -- x
SELECT * FROM AbsentTypes; -- x
SELECT * FROM AbsentLogs; -- x
SELECT * FROM SalaryLogs; -- x

SELECT e.Id, e.Name, e.Address, p.NamePosition, t.NameWorkType, p.BaseSalary, et.NameEduType, s.NameState
FROM Employees e, PositionTypes p, EducationTypes et, EmployeeStates s, WorkTypes t
WHERE 
	e.IdEduType = et.IdEduType
	AND e.IdPosition = p.IdPosition 
	AND e.IdState = s.IdState
	AND p.IdWorkType = t.IdWorkType;
