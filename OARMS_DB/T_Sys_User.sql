﻿CREATE TABLE [dbo].[T_Sys_User]
(
	[FID] NVARCHAR(50) NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [UserCode] NVARCHAR(50) NOT NULL, 
    [UserName] NVARCHAR(50) NULL DEFAULT 未定义用户名, 
    [Password] NVARCHAR(20) NOT NULL DEFAULT 123456
)
