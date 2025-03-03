using Domain.BaseEntities;
using Repository.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection;
using System.Security.Principal;

namespace Repository.Common;

public interface IUnitOfWork
{
    public IProductRepository ProductRepository { get; }
    public ICustomerRepository CustomerRepository { get; }
    public IUserRepository UserRepository { get; }
    public ITableRepository TableRepository { get; }    
    Task<int> SaveChanges();

}
//CREATE TABLE Users(
//    Id INT IDENTITY(1,1) PRIMARY KEY,
//    Name NVARCHAR(100) NOT NULL,
//    Surname NVARCHAR(100) NOT NULL,
//    Username NVARCHAR(100) NOT NULL UNIQUE,
//    FatherName NVARCHAR(100) NULL,
//    Email NVARCHAR(255) NOT NULL CHECK(Email NOT LIKE '%@%'), -- Email olmamalıdır
//    PasswordHash NVARCHAR(500) NOT NULL,
//    Address NVARCHAR(255) NULL,
//    MobilePhone NVARCHAR(20) NULL CHECK(MobilePhone NOT LIKE '+994%'), -- "+994" ilə başlamasın
//    CardNumber NVARCHAR(16) NULL CHECK(LEN(CardNumber) = 16), -- 16 rəqəm olmalıdır
//    TableNumber NVARCHAR(50) NULL,
//    Birthdate DATE NOT NULL,
//    DateOfEmployment DATE NOT NULL,
//    DateOfDismissal DATE NULL,
//    Note NVARCHAR(500) NULL,
//    Gender NVARCHAR(20) NOT NULL, -- Enum üçün string saxlaya bilərik
//    UserType NVARCHAR(20) NOT NULL, -- Enum üçün string saxlaya bilərik
    
//    -- BaseEntity properties
//    CreatedBy INT NULL,
//    UpdatedBy INT NULL,
//    DeletedBy INT NULL,
//    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
//    UpdatedDate DATETIME NULL,
//    DeletedDate DATETIME NULL,
//    IsDeleted BIT NOT NULL DEFAULT 0
//);
