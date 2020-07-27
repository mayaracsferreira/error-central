using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErrorCentral.Infra.Data.Migrations
{
    public partial class PopulaBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "EventLog",
                columns: new[] { "ID", "Archived", "Collected", "CreatedDate", "Description", "Environment", "Level", "Log", "Origin", "Title" },
                values: new object[,]
                {
                    { 1000, false, "yvqnygr3i1xl47wanrg2", new DateTime(2008, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), "It is thrown when an input-output operation failed or interrupted", "Development", "ERROR", "IOException", "app.server.com.br", "development.StaticOperation.Service: <failed>" },
                    { 1023, false, "g5d9yj5plmeftg3goedl", new DateTime(2020, 6, 1, 1, 30, 43, 0, DateTimeKind.Unspecified), "It is thrown when a class does not contain the field (or variable) specified", "production", "DEBUG", "NoSuchFieldException", "127.0.0.1", "production.UserName.Dbase: <thrown>" },
                    { 1024, false, "5zwo48gd9gnitmfnuizy", new DateTime(2020, 7, 1, 1, 30, 43, 0, DateTimeKind.Unspecified), "It is thrown to indicate that an array has been accessed with an illegal index. The index is either negative or greater than or equal to the size of the array.", "development", "ERROR", "ArrayIndexOutOfBoundsException", "app.server.com.br", "development.ListProducts.Service: <illegal>" },
                    { 1025, false, "w0mr2nx5wayoj6heecsf", new DateTime(2020, 2, 1, 1, 30, 43, 0, DateTimeKind.Unspecified), "This exception is raised when referring to the members of a null object. Null represents nothing", "development", "WARNING", "NullPointerException", "app.server.com.br", "development.ListProducts.GetEvent: <exception>" },
                    { 1026, false, "5zwo48gd9gnitmfnuizy", new DateTime(2020, 5, 1, 1, 30, 43, 0, DateTimeKind.Unspecified), "It is thrown when accessing a method which is not found.", "development", "WARNING", "NoSuchMethodException", "app.server.com.br", "development.ListProducts.Access: <notfound>" },
                    { 1027, false, "g5d9yj5plmeftg3goedl", new DateTime(2020, 5, 1, 1, 30, 43, 0, DateTimeKind.Unspecified), "It is thrown when accessing a method which is not found.", "development", "DEBUG", "NoSuchMethodException", "app.server.com.br", "development.GetEvent.Service:<thrown>" },
                    { 1028, false, "mgv7emwke7mr9mo5wsgj", new DateTime(2020, 5, 5, 3, 30, 43, 0, DateTimeKind.Unspecified), "It is thrown when a class does not contain the field (or variable) specified", "development", "WARNING", "NoSuchFieldException", "10.0.1.1", "development.Index.Access: <notfound>" },
                    { 1029, false, "w0mr2nx5wayoj6heecsf", new DateTime(2020, 5, 5, 3, 30, 43, 0, DateTimeKind.Unspecified), "It is thrown when a thread is waiting , sleeping , or doing some processing , and it is interrupted.", "production", "ERROR", "InterruptedException", "app.server.com.br", "production.GetEvent.Validation: <interrupted>" },
                    { 1022, false, "g5d9yj5plmeftg3goedl", new DateTime(2020, 6, 1, 1, 30, 43, 0, DateTimeKind.Unspecified), "It is thrown by String class methods to indicate that an index is either negative than the size of the string", "homologation", "DEBUG", "StringIndexOutOfBoundsException", "10.0.1.1", "homologation.GetIndex.Interface: <string>" },
                    { 1030, false, "mgv7emwke7mr9mo5wsgj", new DateTime(2020, 5, 5, 3, 30, 43, 0, DateTimeKind.Unspecified), "It is thrown by String class methods to indicate that an index is either negative than the size of the string", "production", "DEBUG", "StringIndexOutOfBoundsException", "app.server.com.br", "production.GetEvent.Validation: <badrequest>" },
                    { 1032, false, "mriqxq386mq6vbfzhf4n", new DateTime(2020, 5, 15, 3, 30, 43, 0, DateTimeKind.Unspecified), "This Exception is raised when we try to access a class whose definition is not found", "development", "WARNING", "ClassNotFoundException", "127.0.0.1", "development.EventCheck.Access: <notfound>" },
                    { 1033, false, "w0mr2nx5wayoj6heecsf", new DateTime(2020, 5, 15, 3, 30, 43, 0, DateTimeKind.Unspecified), "It is thrown when an exceptional condition has occurred in an arithmetic operation.", "development", "DEBUG", "ArithmeticException", "10.0.1.1", "development.MathArray.Service: <exceptional>" },
                    { 1034, false, "g5d9yj5plmeftg3goedl", new DateTime(2020, 5, 20, 3, 30, 43, 0, DateTimeKind.Unspecified), "It is thrown when an input-output operation failed or interrupted", "production", "WARNING", "IOException", "app.server.com.br", "production.SelectPrice.Service: <interrupted>" },
                    { 1035, false, "g5d9yj5plmeftg3goedl", new DateTime(2020, 5, 20, 3, 30, 43, 0, DateTimeKind.Unspecified), "It is thrown when an input-output operation failed or interrupted", "development", "DEBUG", "IOException", "127.0.0.1", "development.GetOperation.Index: <interrupted>" },
                    { 1036, false, "mriqxq386mq6vbfzhf4n", new DateTime(2020, 5, 20, 3, 30, 43, 0, DateTimeKind.Unspecified), "It is thrown when a thread is waiting , sleeping , or doing some processing , and it is interrupted.", "production", "WARNING", "InterruptedException", "app.server.com.br", "production.GetUserList.Service: <thrown>" },
                    { 1037, false, "g5d9yj5plmeftg3goedl", new DateTime(2020, 5, 20, 5, 30, 43, 0, DateTimeKind.Unspecified), "This represents any exception which occurs during runtime.", "development", "ERROR", "RuntimeException", "10.0.1.1", "development.UserArray.AccessInterface: <exception>" },
                    { 1038, false, "g5d9yj5plmeftg3goedl", new DateTime(2020, 4, 23, 5, 30, 43, 0, DateTimeKind.Unspecified), "It is thrown when a thread is waiting , sleeping , or doing some processing , and it is interrupted.", "development", "ERROR", "InterruptedException", "10.0.1.1", "development.User.AddUser:<invalid>" },
                    { 1031, false, "mriqxq386mq6vbfzhf4n", new DateTime(2020, 5, 15, 3, 30, 43, 0, DateTimeKind.Unspecified), "This represents any exception which occurs during runtime.", "production", "ERROR", "RuntimeException", "127.0.0.1", "production.GetEvent.Service: <exception>" },
                    { 1021, false, "g5d9yj5plmeftg3goedl", new DateTime(2020, 3, 15, 9, 20, 45, 0, DateTimeKind.Unspecified), "This exception is raised when a method could not convert a string into a numeric format.", "development", "DEBUG", "NumberFormatException", "app.server.com.br", "development.GetID.API: <exception>" },
                    { 1020, false, "5zwo48gd9gnitmfnuizy", new DateTime(2020, 4, 15, 9, 20, 45, 0, DateTimeKind.Unspecified), "It is thrown to indicate that an array has been accessed with an illegal index. The index is either negative or greater than or equal to the size of the array.", "homologation", "DEBUG", "ArrayIndexOutOfBoundsException", "127.0.0.1", "homologation.MoqIndex.Service: <illegal>" },
                    { 1019, false, "w0mr2nx5wayoj6heecsf", new DateTime(2020, 4, 15, 9, 20, 45, 0, DateTimeKind.Unspecified), "It is thrown when a thread is waiting , sleeping , or doing some processing , and it is interrupted.", "development", "WARNING", "InterruptedException", "app.server.com.br", "development.AccessThread.Service: <interrupted>" },
                    { 1001, false, "5zwo48gd9gnitmfnuizy", new DateTime(2019, 6, 2, 9, 30, 1, 0, DateTimeKind.Unspecified), "It is thrown when an exceptional condition has occurred in an arithmetic operation.", "development", "ERROR", "ArithmeticException", "127.0.0.1", "development.MathCondition.Service: <thrown>" },
                    { 1002, false, "g5d9yj5plmeftg3goedl", new DateTime(2019, 7, 3, 9, 0, 52, 0, DateTimeKind.Unspecified), "It is thrown when an exceptional condition has occurred in an arithmetic operation.", "homologation", "ERROR", "ArithmeticException", "app.server.com.br", "development.MathCondition.Service: <thrown>" },
                    { 1003, false, "5zwo48gd9gnitmfnuizy", new DateTime(2019, 6, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), "It is thrown when an exceptional condition has occurred in an arithmetic operation.", "homologation", "WARNING", "ArithmeticException", "app.server.com.br", "development.MathCondition.Service: <thrown>" },
                    { 1004, false, "g5d9yj5plmeftg3goedl", new DateTime(2019, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), "This Exception is raised when a file is not accessible or does not open.", "production", "ERROR", "FileNotFoundException", "app.server.com.br", "production.RaisedUser.Service: <unreachable>" },
                    { 1005, false, "abgy5vpriw79xmm2h4cz", new DateTime(2019, 5, 1, 8, 30, 52, 0, DateTimeKind.Unspecified), "This exception is raised when referring to the members of a null object. Null represents nothing", "homologation", "WARNING", "NullPointerException", "10.0.1.1", "homologation.GetUserValidation.View: <null>" },
                    { 1006, false, "abgy5vpriw79xmm2h4cz", new DateTime(2019, 7, 3, 9, 0, 52, 0, DateTimeKind.Unspecified), "It is thrown by String class methods to indicate that an index is either negative than the size of the string", "development", "ERROR", "StringIndexOutOfBoundsException", "127.0.0.1", "development.ListofObjects.Service: <unreachable>" },
                    { 1007, false, "abgy5vpriw79xmm2h4cz", new DateTime(2019, 7, 3, 9, 0, 52, 0, DateTimeKind.Unspecified), "This represents any exception which occurs during runtime.", "homologation", "WARNING", "RuntimeException", "10.0.1.1", "development.Events.Service: <outoftime>" },
                    { 1008, false, "g5d9yj5plmeftg3goedl", new DateTime(2019, 8, 15, 15, 25, 30, 0, DateTimeKind.Unspecified), "It is thrown when an exceptional condition has occurred in an arithmetic operation.", "homologation", "DEBUG", "ArithmeticException", "10.0.1.1", "development.MathCondition.Service: <thrown>" },
                    { 1009, false, "5zwo48gd9gnitmfnuizy", new DateTime(2019, 8, 15, 15, 25, 30, 0, DateTimeKind.Unspecified), "It is thrown when accessing a method which is not found.", "production", "ERROR", "NoSuchMethodException", "127.0.0.1", "production.GetUserList.Class : <unreachable>" },
                    { 1010, false, "5zwo48gd9gnitmfnuizy", new DateTime(2019, 1, 15, 15, 25, 30, 0, DateTimeKind.Unspecified), "This Exception is raised when we try to access a class whose definition is not found", "production", "WARNING", "ClassNotFoundException", "127.0.0.1", "production.GetEvent.Class : <notfound>" },
                    { 1012, false, "xvsbo5fum53jznq00xca", new DateTime(2019, 1, 15, 5, 25, 30, 0, DateTimeKind.Unspecified), "This exception is raised when a method could not convert a string into a numeric format.", "development", "DEBUG", "NumberFormatException", "127.0.0.1", "production.GetEvent.Class : <notauthorized>" },
                    { 1013, false, "yvqnygr3i1xl47wanrg2", new DateTime(2019, 1, 15, 13, 25, 30, 0, DateTimeKind.Unspecified), "It is thrown when accessing a method which is not found.", "homologation", "WARNING", "NoSuchMethodException", "10.0.1.1", "homologation.GetUserList.Class : <notfound>" },
                    { 1014, false, "5zwo48gd9gnitmfnuizy", new DateTime(2019, 3, 15, 15, 25, 30, 0, DateTimeKind.Unspecified), "This exception is raised when a method could not convert a string into a numeric format.", "development", "WARNING", "NumberFormatException", "10.0.1.1", "development.UserName.GetEvent : <convert>" },
                    { 1015, false, "xvsbo5fum53jznq00xca", new DateTime(2020, 1, 15, 15, 25, 30, 0, DateTimeKind.Unspecified), "It is thrown when an input-output operation failed or interrupted", "homologation", "DEBUG", "IOException", "app.server.com.br", "homologation.MathCondition.Service: <failed>" },
                    { 1016, false, "w0mr2nx5wayoj6heecsf", new DateTime(2020, 7, 15, 15, 25, 30, 0, DateTimeKind.Unspecified), "It is thrown to indicate that an array has been accessed with an illegal index. The index is either negative or greater than or equal to the size of the array.", "development", "DEBUG", "ArrayIndexOutOfBoundsException", "app.server.com.br", "development.Index.Access: <illegal>" },
                    { 1017, false, "xvsbo5fum53jznq00xca", new DateTime(2020, 3, 15, 9, 20, 30, 0, DateTimeKind.Unspecified), "It is thrown to indicate that an array has been accessed with an illegal index. The index is either negative or greater than or equal to the size of the array.", "production", "WARNING", "ArrayIndexOutOfBoundsException", "10.0.1.1", "production.Index.Access: <illegal>" },
                    { 1018, false, "w0mr2nx5wayoj6heecsf", new DateTime(2020, 4, 15, 9, 20, 30, 0, DateTimeKind.Unspecified), "It is thrown when an exceptional condition has occurred in an arithmetic operation.", "production", "ERROR", "ArithmeticException", "app.server.com.br", "production.MathArray.Service: <exceptional>" },
                    { 1039, false, "mgv7emwke7mr9mo5wsgj", new DateTime(2020, 5, 20, 5, 30, 43, 0, DateTimeKind.Unspecified), "This exception is raised when a method could not convert a string into a numeric format.", "production", "WARNING", "NumberFormatException", "10.0.1.1", "production.MathArray.Service:<exception>" },
                    { 1040, false, "mgv7emwke7mr9mo5wsgj", new DateTime(2020, 5, 20, 5, 30, 43, 0, DateTimeKind.Unspecified), "This Exception is raised when a file is not accessible or does not open.", "development", "ERROR", "FileNotFoundException", "10.0.1.1", "development.GetOperation.Service: <denied>" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1023);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1024);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1025);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1026);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1027);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1028);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1029);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1030);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1031);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1032);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1033);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1034);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1035);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1036);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1037);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1038);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1039);

            migrationBuilder.DeleteData(
                table: "EventLog",
                keyColumn: "ID",
                keyValue: 1040);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
