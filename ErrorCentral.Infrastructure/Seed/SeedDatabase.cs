using ErrorCentral.AppDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Infra.Data.Seed
{
    public static class SeedDatabase
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventLog>().HasData(
                new EventLog
                {
                    EventID = 1000,
                    Level = "ERROR",
                    Title = "development.StaticOperation.Service: <failed>",
                    CollectedBy = "yvqnygr3i1xl47wanrg2",
                    Log = "IOException",
                    Description = "It is thrown when an input-output operation failed or interrupted",
                    Origin = "app.server.com.br",
                    Environment = "Development",
                    CreatedDate = new DateTime(2008, 5, 1, 8, 30, 52)
                },
                new EventLog
                {
                    EventID = 1001,
		            Title = "development.MathCondition.Service: <thrown>",
                    CreatedDate = new DateTime(2019, 6, 2, 9, 30, 01),
                    Description = "It is thrown when an exceptional condition has occurred in an arithmetic operation.",
                    Environment = "development",
                    Level = "ERROR",
                    Log = "ArithmeticException",
                    Origin = "127.0.0.1",
		            CollectedBy = "5zwo48gd9gnitmfnuizy"
                },
                new EventLog
                {
                    EventID = 1002,
		            Title = "development.MathCondition.Service: <thrown>",
                    CreatedDate = new DateTime(2019, 7, 3, 9, 00, 52),
                    Description = "It is thrown when an exceptional condition has occurred in an arithmetic operation.",
                    Environment = "homologation",
                    Level = "ERROR",
                    Log = "ArithmeticException",
                    Origin = "app.server.com.br",
		            CollectedBy = "g5d9yj5plmeftg3goedl"
                },
                new EventLog
                {
                    EventID = 1003, 
		            Title = "development.MathCondition.Service: <thrown>",
                    CreatedDate = new DateTime(2019, 6, 1, 8, 30, 52),
                    Description = "It is thrown when an exceptional condition has occurred in an arithmetic operation.",
                    Environment = "homologation",
                    Level = "WARNING",
                    Log = "ArithmeticException",
                    Origin = "app.server.com.br",
		            CollectedBy = "5zwo48gd9gnitmfnuizy"
                },
                new EventLog
                {
                    EventID = 1004, 
		            Title = "production.RaisedUser.Service: <unreachable>",
                    CreatedDate = new DateTime(2019, 5, 1, 8, 30, 52),
                    Description = "This Exception is raised when a file is not accessible or does not open.",
                    Environment = "production",
                    Level = "ERROR",
                    Log = "FileNotFoundException",
                    Origin = "app.server.com.br",
                    CollectedBy = "g5d9yj5plmeftg3goedl"
                },
                new EventLog
                {
                    EventID = 1005, 
		            Title = "homologation.GetUserValidation.View: <null>",
                    CreatedDate = new DateTime(2019, 5, 1, 8, 30, 52),
                    Description = "This exception is raised when referring to the members of a null object. Null represents nothing",
                    Environment = "homologation",
                    Level = "WARNING",
                    Log = "NullPointerException",
                    Origin = "10.0.1.1",
		            CollectedBy = "abgy5vpriw79xmm2h4cz"
                },
                new EventLog
                {
                    EventID = 1006, 
		            Title = "development.ListofObjects.Service: <unreachable>",
                    CreatedDate = new DateTime(2019, 7, 3, 9, 00, 52),
                    Description = "It is thrown by String class methods to indicate that an index is either negative than the size of the string",
                    Environment = "development",
                    Level = "ERROR",
                    Log = "StringIndexOutOfBoundsException",
                    Origin = "127.0.0.1",
		            CollectedBy = "abgy5vpriw79xmm2h4cz"
                },
                new EventLog
                {
                    EventID = 1007, 
		            Title = "development.Events.Service: <outoftime>",
                    CreatedDate = new DateTime(2019, 7, 3, 9, 00, 52),
                    Description = "This represents any exception which occurs during runtime.",
                    Environment = "homologation",
                    Level = "WARNING",
                    Log = "RuntimeException",
                    Origin = "10.0.1.1",
		            CollectedBy = "abgy5vpriw79xmm2h4cz"
                },
                new EventLog
                {
                    EventID = 1008, 
		            Title = "development.MathCondition.Service: <thrown>",
                    CreatedDate = new DateTime(2019, 8, 15, 15, 25, 30),
                    Description = "It is thrown when an exceptional condition has occurred in an arithmetic operation.",
                    Environment = "homologation",
                    Level = "DEBUG",
                    Log = "ArithmeticException",
                    Origin = "10.0.1.1",
		            CollectedBy = "g5d9yj5plmeftg3goedl"
                },
                new EventLog
                {
                    EventID = 1009, 
		            Title = "production.GetUserList.Class : <unreachable>",
                    CreatedDate = new DateTime(2019, 8, 15, 15, 25, 30),
                    Description = "It is thrown when accessing a method which is not found.",
                    Environment = "production",
                    Level = "ERROR",
                    Log = "NoSuchMethodException",
                    Origin = "127.0.0.1",
		            CollectedBy = "5zwo48gd9gnitmfnuizy"
                },
                new EventLog
                {
                    EventID = 1010, 
		            Title = "production.GetEvent.Class : <notfound>",
                    CreatedDate = new DateTime(2019, 1, 15, 15, 25, 30),
                    Description = "This Exception is raised when we try to access a class whose definition is not found",
                    Environment = "production",
                    Level = "WARNING",
                    Log = "ClassNotFoundException",
                    Origin = "127.0.0.1",
		            CollectedBy = "5zwo48gd9gnitmfnuizy"
                },
                new EventLog
                {
                    EventID = 1012, 
		            Title = "production.GetEvent.Class : <notauthorized>",
                    CreatedDate = new DateTime(2019, 1, 15, 5, 25, 30),
                    Description = "This exception is raised when a method could not convert a string into a numeric format.",
                    Environment = "development",
                    Level = "DEBUG",
                    Log = "NumberFormatException",
                    Origin = "127.0.0.1",
		            CollectedBy = "xvsbo5fum53jznq00xca"
                },
                new EventLog
                {
                    EventID = 1013, 
		            Title = "homologation.GetUserList.Class : <notfound>",
                    CreatedDate = new DateTime(2019, 1, 15, 13, 25, 30),
                    Description = "It is thrown when accessing a method which is not found.",
                    Environment = "homologation",
                    Level = "WARNING",
                    Log = "NoSuchMethodException",
                    Origin = "10.0.1.1",
                    CollectedBy = "yvqnygr3i1xl47wanrg2"
                },
                new EventLog
                {
                    EventID = 1014, 
		            Title = "development.UserName.GetEvent : <convert>",
                    CreatedDate = new DateTime(2019, 3, 15, 15, 25, 30),
                    Description = "This exception is raised when a method could not convert a string into a numeric format.",
                    Environment = "development",
                    Level = "WARNING",
                    Log = "NumberFormatException",
                    Origin = "10.0.1.1",
		            CollectedBy = "5zwo48gd9gnitmfnuizy"
                },
                new EventLog
                {
                    EventID = 1015, 
		            Title = "homologation.MathCondition.Service: <failed>", 
                    CreatedDate = new DateTime(2020, 1, 15, 15, 25, 30),
                    Description = "It is thrown when an input-output operation failed or interrupted",
                    Environment = "homologation",
                    Level = "DEBUG",
                    Log = "IOException",
                    Origin = "app.server.com.br",
		            CollectedBy = "xvsbo5fum53jznq00xca"
                },
                new EventLog
                {
                    EventID = 1016, 
		            Title = "development.Index.Access: <illegal>",
                    CreatedDate = new DateTime(2020, 7, 15, 15, 25, 30),
                    Description = "It is thrown to indicate that an array has been accessed with an illegal index. The index is either negative or greater than or equal to the size of the array.",
                    Environment = "development",
                    Level = "DEBUG",
                    Log = "ArrayIndexOutOfBoundsException",
                    Origin = "app.server.com.br",
                    CollectedBy = "w0mr2nx5wayoj6heecsf"
                },
                new EventLog
                {
                    EventID = 1017, 
		            Title = "production.Index.Access: <illegal>",
                    CreatedDate = new DateTime(2020, 3, 15, 9, 20, 30),
                    Description = "It is thrown to indicate that an array has been accessed with an illegal index. The index is either negative or greater than or equal to the size of the array.",
                    Environment = "production",
                    Level = "WARNING",
                    Log = "ArrayIndexOutOfBoundsException",
                    Origin = "10.0.1.1",
		            CollectedBy = "xvsbo5fum53jznq00xca"
                },
                new EventLog
                {
                    EventID = 1018, 
		            Title = "production.MathArray.Service: <exceptional>",
                    CreatedDate = new DateTime(2020, 4, 15, 9, 20, 30),
                    Description = "It is thrown when an exceptional condition has occurred in an arithmetic operation.",
                    Environment = "production",
                    Level = "ERROR",
                    Log = "ArithmeticException",
                    Origin = "app.server.com.br",
                    CollectedBy = "w0mr2nx5wayoj6heecsf"
                },
                new EventLog
                {
                    EventID = 1019, 
		            Title = "development.AccessThread.Service: <interrupted>",
                    CreatedDate = new DateTime(2020, 4, 15, 9, 20, 45),
                    Description = "It is thrown when a thread is waiting , sleeping , or doing some processing , and it is interrupted.",
                    Environment = "development",
                    Level = "WARNING",
                    Log = "InterruptedException",
                    Origin = "app.server.com.br",
		            CollectedBy = "w0mr2nx5wayoj6heecsf"
                },
                new EventLog
                {
                    EventID = 1020, 
		            Title = "homologation.MoqIndex.Service: <illegal>",
                    CreatedDate = new DateTime(2020, 4, 15, 9, 20, 45),
                    Description = "It is thrown to indicate that an array has been accessed with an illegal index. The index is either negative or greater than or equal to the size of the array.",
                    Environment = "homologation",
                    Level = "DEBUG",
                    Log = "ArrayIndexOutOfBoundsException",
                    Origin = "127.0.0.1",
                    CollectedBy = "5zwo48gd9gnitmfnuizy"
                },
                new EventLog
                {
                    EventID = 1021, 
		            Title = "development.GetID.API: <exception>",
                    CreatedDate = new DateTime(2020, 3, 15, 9, 20, 45),
                    Description = "This exception is raised when a method could not convert a string into a numeric format.",
                    Environment = "development",
                    Level = "DEBUG",
                    Log = "NumberFormatException",
                    Origin = "app.server.com.br",
                    CollectedBy = "g5d9yj5plmeftg3goedl"
                },
                new EventLog
                {
                    EventID = 1022, 
		            Title = "homologation.GetIndex.Interface: <string>",
                    CreatedDate = new DateTime(2020, 6, 1, 1, 30, 43),
                    Description = "It is thrown by String class methods to indicate that an index is either negative than the size of the string",
                    Environment = "homologation",
                    Level = "DEBUG",
                    Log = "StringIndexOutOfBoundsException",
                    Origin = "10.0.1.1",
		            CollectedBy = "g5d9yj5plmeftg3goedl"
                },
                new EventLog
                {
                    EventID = 1023, 
		            Title = "production.UserName.Dbase: <thrown>",
                    CreatedDate = new DateTime(2020, 6, 1, 1, 30, 43),
                    Description = "It is thrown when a class does not contain the field (or variable) specified",
                    Environment = "production",
                    Level = "DEBUG",
                    Log = "NoSuchFieldException",
                    Origin = "127.0.0.1",
                    CollectedBy = "g5d9yj5plmeftg3goedl"
                },
                new EventLog
                {
                    EventID = 1024, 
		            Title = "development.ListProducts.Service: <illegal>",
                    CreatedDate = new DateTime(2020, 7, 1, 1, 30, 43),
                    Description = "It is thrown to indicate that an array has been accessed with an illegal index. The index is either negative or greater than or equal to the size of the array.",
                    Environment = "development",
                    Level = "ERROR",
                    Log = "ArrayIndexOutOfBoundsException",
                    Origin = "app.server.com.br",
                    CollectedBy = "5zwo48gd9gnitmfnuizy"
                },
                new EventLog
                {
                    EventID = 1025, 
		            Title = "development.ListProducts.GetEvent: <exception>",
                    CreatedDate = new DateTime(2020, 2, 1, 1, 30, 43),
                    Description = "This exception is raised when referring to the members of a null object. Null represents nothing",
                    Environment = "development",
                    Level = "WARNING",
                    Log = "NullPointerException",
                    Origin = "app.server.com.br",
		            CollectedBy = "w0mr2nx5wayoj6heecsf"
                },
                new EventLog
                {
                    EventID = 1026, 
		            Title = "development.ListProducts.Access: <notfound>",
                    CreatedDate = new DateTime(2020, 5, 1, 1, 30, 43),
                    Description = "It is thrown when accessing a method which is not found.",
                    Environment = "development",
                    Level = "WARNING",
                    Log = "NoSuchMethodException",
                    Origin = "app.server.com.br",
                    CollectedBy = "5zwo48gd9gnitmfnuizy",
                },
                new EventLog
                {
                    EventID = 1027, 
		            Title = "development.GetEvent.Service:<thrown>",
                    CreatedDate = new DateTime(2020, 5, 1, 1, 30, 43),
                    Description = "It is thrown when accessing a method which is not found.",
                    Environment = "development",
                    Level = "DEBUG",
                    Log = "NoSuchMethodException",
                    Origin = "app.server.com.br",
                    CollectedBy = "g5d9yj5plmeftg3goedl"
                },
                new EventLog
                {
                    EventID = 1028, 
		            Title = "development.Index.Access: <notfound>",
                    CreatedDate = new DateTime(2020, 5, 5, 3, 30, 43),
                    Description = "It is thrown when a class does not contain the field (or variable) specified",
                    Environment = "development",
                    Level = "WARNING",
                    Log = "NoSuchFieldException",
                    Origin = "10.0.1.1",
		            CollectedBy = "mgv7emwke7mr9mo5wsgj"
                },
                new EventLog
                {
                    EventID = 1029, 
		            Title = "production.GetEvent.Validation: <interrupted>",
                    CreatedDate = new DateTime(2020, 5, 5, 3, 30, 43),
                    Description = "It is thrown when a thread is waiting , sleeping , or doing some processing , and it is interrupted.",
                    Environment = "production",
                    Level = "ERROR",
                    Log = "InterruptedException",
                    Origin = "app.server.com.br",
		            CollectedBy = "w0mr2nx5wayoj6heecsf"
                },
                new EventLog
                {
                    EventID = 1030, 
		            Title = "production.GetEvent.Validation: <badrequest>",
                    CreatedDate = new DateTime(2020, 5, 5, 3, 30, 43),
                    Description = "It is thrown by String class methods to indicate that an index is either negative than the size of the string",
                    Environment = "production",
                    Level = "DEBUG",
                    Log = "StringIndexOutOfBoundsException",
                    Origin = "app.server.com.br",
                    CollectedBy = "mgv7emwke7mr9mo5wsgj"
                },
                new EventLog
                {
                    EventID = 1031, 
		            Title = "production.GetEvent.Service: <exception>",
                    CreatedDate = new DateTime(2020, 5, 15, 3, 30, 43),
                    Description = "This represents any exception which occurs during runtime.",
                    Environment = "production",
                    Level = "ERROR",
                    Log = "RuntimeException",
                    Origin = "127.0.0.1",
                    CollectedBy = "mriqxq386mq6vbfzhf4n"
                },
                new EventLog
                {
                    EventID = 1032, 
		            Title = "development.EventCheck.Access: <notfound>",
                    CreatedDate = new DateTime(2020, 5, 15, 3, 30, 43),
                    Description = "This Exception is raised when we try to access a class whose definition is not found",
                    Environment = "development",
                    Level = "WARNING",
                    Log = "ClassNotFoundException",
                    Origin = "127.0.0.1",
                    CollectedBy = "mriqxq386mq6vbfzhf4n"
                },
                new EventLog
                {
                    EventID = 1033, 
		            Title = "development.MathArray.Service: <exceptional>",
                    CreatedDate = new DateTime(2020, 5, 15, 3, 30, 43),
                    Description = "It is thrown when an exceptional condition has occurred in an arithmetic operation.",
                    Environment = "development",
                    Level = "DEBUG",
                    Log = "ArithmeticException",
                    Origin = "10.0.1.1",
                    CollectedBy = "w0mr2nx5wayoj6heecsf"
                },
                new EventLog
                {
                    EventID = 1034, 
		            Title = "production.SelectPrice.Service: <interrupted>",
                    CreatedDate = new DateTime(2020, 5, 20, 3, 30, 43),
                    Description = "It is thrown when an input-output operation failed or interrupted",
                    Environment = "production",
                    Level = "WARNING",
                    Log = "IOException",
                    Origin = "app.server.com.br",
                    CollectedBy = "g5d9yj5plmeftg3goedl"
                },
                new EventLog
                {
                    EventID = 1035, 
		            Title = "development.GetOperation.Index: <interrupted>",	
                    CreatedDate = new DateTime(2020, 5, 20, 3, 30, 43),
                    Description = "It is thrown when an input-output operation failed or interrupted",
                    Environment = "development",
                    Level = "DEBUG",
                    Log = "IOException",
                    Origin = "127.0.0.1",
		            CollectedBy = "g5d9yj5plmeftg3goedl"
                },
                new EventLog
                {
                    EventID = 1036, 
		            Title = "production.GetUserList.Service: <thrown>",
                    CreatedDate = new DateTime(2020, 5, 20, 3, 30, 43),
                    Description = "It is thrown when a thread is waiting , sleeping , or doing some processing , and it is interrupted.",
                    Environment = "production",
                    Level = "WARNING",
                    Log = "InterruptedException",
                    Origin = "app.server.com.br",
                    CollectedBy = "mriqxq386mq6vbfzhf4n"
                },
                new EventLog
                {
                    EventID = 1037, 
		            Title = "development.UserArray.AccessInterface: <exception>",
                    CreatedDate = new DateTime(2020, 5, 20, 5, 30, 43),
                    Description = "This represents any exception which occurs during runtime.",
                    Environment = "development",
                    Level = "ERROR",
                    Log = "RuntimeException",
                    Origin = "10.0.1.1",
		            CollectedBy = "g5d9yj5plmeftg3goedl"
                },
                new EventLog
                {
                    EventID = 1038, 
		            Title = "development.User.AddUser:<invalid>",
                    CreatedDate = new DateTime(2020, 4, 23, 5, 30, 43),
                    Description = "It is thrown when a thread is waiting , sleeping , or doing some processing , and it is interrupted.",
                    Environment = "development",
                    Level = "ERROR",
                    Log = "InterruptedException",
                    Origin = "10.0.1.1",
                    CollectedBy = "g5d9yj5plmeftg3goedl"
                },
                new EventLog
                {
                    EventID = 1039, 
		            Title = "production.MathArray.Service:<exception>",
                    CreatedDate = new DateTime(2020, 5, 20, 5, 30, 43),
                    Description = "This exception is raised when a method could not convert a string into a numeric format.",
                    Environment = "production",
                    Level = "WARNING",
                    Log = "NumberFormatException",
                    Origin = "10.0.1.1",
		            CollectedBy = "mgv7emwke7mr9mo5wsgj"
                },
                new EventLog
                {
                    EventID = 1040, 
		            Title = "development.GetOperation.Service: <denied>",
                    CreatedDate = new DateTime(2020, 5, 20, 5, 30, 43),
                    Description = "This Exception is raised when a file is not accessible or does not open.",
                    Environment = "development",
                    Level = "ERROR",
                    Log = "FileNotFoundException",
                    Origin = "10.0.1.1",
                    CollectedBy = "mgv7emwke7mr9mo5wsgj"
                }
            );
        }
    }
}