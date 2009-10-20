USE [EduSim]
GO
/****** Object:  Table [dbo].[RoundCategory]    Script Date: 10/20/2009 07:47:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoundCategory](
	[Id] [int] NOT NULL,
	[RoundName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 10/20/2009 07:47:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[USP_APPMGMTGenericDelete]    Script Date: 10/20/2009 07:45:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Ashish>
-- Create date: <Create Date,18-10-08>
-- Description:	<Description,To be used in XML Based Forms>
-- =============================================
Create PROCEDURE [dbo].[USP_APPMGMTGenericDelete] 
	-- Add the parameters for the stored procedure here
	@TableName varchar(100),
@PrimaryKeyName  varchar(100),
@IDs varchar(4000)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here

DECLARE @sqlStr NVARCHAR(4000)
	
			SET @sqlStr =  'Delete from '+@TableName+' where '+@PrimaryKeyName+' in ('+@IDs+')'
		
	
	EXEC  sp_executesql @sqlStr
END
GO
/****** Object:  Table [dbo].[GameInitialData]    Script Date: 10/20/2009 07:46:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameInitialData](
	[SegmentTypeId] [int] NOT NULL,
	[UnitSold] [float] NOT NULL,
	[UnitInventory] [float] NOT NULL,
	[RevisionDate] [datetime] NOT NULL,
	[AgeDec31] [float] NOT NULL,
	[Reliability] [float] NOT NULL,
	[Performance] [float] NOT NULL,
	[Size] [float] NOT NULL,
	[SalesExpense] [float] NOT NULL,
	[MarketingExpense] [float] NOT NULL,
	[Price] [float] NOT NULL,
	[MaterialCost] [float] NOT NULL,
	[LabourCost] [float] NOT NULL,
	[Overtime] [float] NOT NULL,
	[AutomationForNextRound] [float] NOT NULL,
	[CapacityForNextRound] [float] NOT NULL,
	[PlantUtilization] [float] NOT NULL,
 CONSTRAINT [PK_GameInitialData] PRIMARY KEY CLUSTERED 
(
	[SegmentTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamCategory]    Script Date: 10/20/2009 07:47:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TeamCategory](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TeamCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[usp_ODS]    Script Date: 10/20/2009 07:45:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ODS]
	@filterText varchar(4000) = null,
	@maxRowsInPage [int] = 10,
	@sortOrder varchar(4000) = 'ID',
	@ObjectName varchar(50),
	@RID int = null,
	@UID int = null, 
	@CurrentPage int OUTPUT,
	@PageCount int OUTPUT,
	@ERPCOMPANY varchar(500) = null
AS
BEGIN
	DECLARE @sqlStr NVARCHAR(4000)
	DECLARE @sqlStr2 NVARCHAR(4000)
	DECLARE @Count numeric(12,2)
	DECLARE @rowStartIdx int
	if @CurrentPage is null 
		set @CurrentPage = 0
	-- format filter text.
	BEGIN
		SET @sqlStr = 'SELECT @CountParam = COUNT(*) FROM '+ @ObjectName + CASE WHEN @filterText IS NOT NULL THEN ' WHERE '+ @filterText ELSE '' END
		
		EXEC sp_executesql @sqlStr, N'@CountParam int OUTPUT', @Count OUTPUT
		
		if ( not (@CurrentPage <> 0 and CEILING(@Count / @maxRowsInPage) >= @CurrentPage))
			set @CurrentPage = (case when @Count > 0 then 1 else 0 end)

		SET @PageCount = (case when @Count > @maxRowsInPage then CEILING(@Count / @maxRowsInPage) else 
			(case when @Count > 0 then 1 else 0 end) end)
			
		SET @rowStartIdx = 1 + (@maxRowsInPage * (CASE WHEN @CurrentPage = 0 THEN 0 ELSE @CurrentPage - 1 END))
		
if(@RID is null)
begin
	SET @sqlStr = 'WITH Entries AS
				(SELECT *' 
				+ CASE WHEN @sortOrder IS NOT NULL THEN ', ROW_NUMBER() OVER (ORDER BY ' + @sortOrder + ') AS RowNum' 
				  ELSE 'ID' 
				  END 
				+ ' FROM '+ @ObjectName 
				+ CASE WHEN @filterText IS NOT NULL THEN ' WHERE '+ @filterText ELSE '' END
				+ ')
				SELECT * FROM Entries WHERE (RowNum BETWEEN ' + CAST(@rowStartIdx AS VARCHAR) + ' AND ' +
				CAST(@rowStartIdx - 1 + ISNULL(@maxRowsInPage,0) AS VARCHAR) + ')'					
		EXEC sp_executesql @sqlStr
end
else
begin


declare @temptable TABLE
	(
	ProjectID int
	)

IF(EXISTS(SELECT 1 FROM APPMGMTEISSetting WHERE EISNAME = 'AX' AND ISACTIVE = 1))
BEGIN
	
	insert into @temptable
	SELECT ProjectId FROM PROJECTProjectUser WHERE RoleId =@RID and UserId =@UID AND ((ProjectId IN (SELECT AMP3ID FROM ERPMGMTOBJECTMAP WHERE AMP3TYPE = 'PROJECT' AND  ERPTYPE = 'Project' AND ERPCOMPANY = @ERPCOMPANY)) OR ProjectId NOT IN (SELECT AMP3ID FROM ERPMGMTOBJECTMAP WHERE AMP3TYPE = 'PROJECT' AND  ERPTYPE = 'Project' AND ERPCOMPANY != @ERPCOMPANY))
END
ELSE
BEGIN
	
	insert into @temptable
	SELECT ProjectId FROM PROJECTProjectUser WHERE RoleId =@RID and UserId =@UID
END
DECLARE @Projects Varchar(4000)
SELECT @Projects =COALESCE(@Projects + ', ', '') + cast(ProjectId as varchar(20)) FROM @temptable


SET @sqlStr = 'SELECT @CountParam = COUNT(*) FROM '+ @ObjectName +' WHERE ProjectID in ('+ @Projects +')' + CASE WHEN @filterText IS NOT NULL THEN +'AND'+ @filterText  ELSE '' END
		
		EXEC sp_executesql @sqlStr, N'@CountParam int OUTPUT', @Count OUTPUT
		
		if ( not (@CurrentPage <> 0 and CEILING(@Count / @maxRowsInPage) >= @CurrentPage))
			set @CurrentPage = (case when @Count > 0 then 1 else 0 end)

		SET @PageCount = (case when @Count > @maxRowsInPage then CEILING(@Count / @maxRowsInPage) else 
			(case when @Count > 0 then 1 else 0 end) end)
			
		SET @rowStartIdx = 1 + (@maxRowsInPage * (CASE WHEN @CurrentPage = 0 THEN 0 ELSE @CurrentPage - 1 END))

		SET @sqlStr = 'WITH Entries AS
				(SELECT *' 
				+ CASE WHEN @sortOrder IS NOT NULL THEN ', ROW_NUMBER() OVER (ORDER BY ' + @sortOrder + ') AS RowNum' 
				  ELSE 'ID' 
				  END 
				+ ' FROM '+ @ObjectName 
				+ ' WHERE ProjectID in ('+ @Projects
				+ '))
				SELECT * FROM Entries WHERE (RowNum BETWEEN ' + CAST(@rowStartIdx AS VARCHAR) + ' AND ' +
				CAST(@rowStartIdx - 1 + ISNULL(@maxRowsInPage,0) AS VARCHAR) + ')'			
		EXEC sp_executesql @sqlStr
	END
	END
END
GO
/****** Object:  StoredProcedure [dbo].[usp_APPMGMTGenericInsert]    Script Date: 10/20/2009 07:45:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE  [dbo].[usp_APPMGMTGenericInsert] 
	@ObjectName varchar(100),
	@Values varchar(4000)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @sqlStr NVARCHAR(4000)

	SET @sqlStr = 'INSERT INTO ' + @ObjectName + ' VALUES (' + @Values + ')'
	PRINT @sqlStr
	EXEC  sp_executesql @sqlStr
END
GO
/****** Object:  Table [dbo].[Game]    Script Date: 10/20/2009 07:46:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Game_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[usp_APPMGMTGenericUpdate]    Script Date: 10/20/2009 07:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[usp_APPMGMTGenericUpdate] 
	@ObjectName varchar(100), 
	@UpdateQuery varchar(8000),
	@WhereClause varchar(8000)
AS
DECLARE @updatedRows int;
BEGIN
	SET NOCOUNT ON;

	DECLARE @sqlStr NVARCHAR(4000)
	SET @sqlStr = 'UPDATE '+ @ObjectName + ' SET ' + @UpdateQuery + ' WHERE ' + @WhereClause
	PRINT @sqlStr
	EXEC  sp_executesql @sqlStr

	SET @updatedRows = @@rowcount;

	SELECT @updatedRows AS rowsUpdated;
END
GO
/****** Object:  Table [dbo].[RoleDetails]    Script Date: 10/20/2009 07:47:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoleDetails](
	[Id] [int] NOT NULL,
	[RoleName] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ConfigurationData]    Script Date: 10/20/2009 07:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ConfigurationData](
	[Name] [varchar](50) NOT NULL,
	[Value] [float] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[InsertGenerator]    Script Date: 10/20/2009 07:45:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[InsertGenerator]
(@tableName varchar(100)) as

--Declare a cursor to retrieve column specific information for the specified table
DECLARE cursCol CURSOR FAST_FORWARD FOR 
SELECT column_name,data_type FROM information_schema.columns WHERE table_name = @tableName
OPEN cursCol
DECLARE @string nvarchar(3000) --for storing the first half of INSERT statement
DECLARE @stringData nvarchar(3000) --for storing the data (VALUES) related statement
DECLARE @dataType nvarchar(1000) --data types returned for respective columns
SET @string='INSERT '+@tableName+'('
SET @stringData=''

DECLARE @colName nvarchar(50)

FETCH NEXT FROM cursCol INTO @colName,@dataType

IF @@fetch_status<>0
	begin
	print 'Table '+@tableName+' not found, processing skipped.'
	close curscol
	deallocate curscol
	return
END

WHILE @@FETCH_STATUS=0
BEGIN
IF @dataType in ('varchar','char','nchar','nvarchar')
BEGIN
	--SET @stringData=@stringData+'''''''''+isnull('+@colName+','''')+'''''',''+'
	SET @stringData=@stringData+''''+'''+isnull('''''+'''''+'+@colName+'+'''''+''''',''NULL'')+'',''+'
END
ELSE
if @dataType in ('text','ntext') --if the datatype is text or something else 
BEGIN
	SET @stringData=@stringData+'''''''''+isnull(cast('+@colName+' as varchar(2000)),'''')+'''''',''+'
END
ELSE
IF @dataType = 'money' --because money doesn't get converted from varchar implicitly
BEGIN
	SET @stringData=@stringData+'''convert(money,''''''+isnull(cast('+@colName+' as varchar(200)),''0.0000'')+''''''),''+'
END
ELSE 
IF @dataType='datetime'
BEGIN
	--SET @stringData=@stringData+'''convert(datetime,''''''+isnull(cast('+@colName+' as varchar(200)),''0'')+''''''),''+'
	--SELECT 'INSERT Authorizations(StatusDate) VALUES('+'convert(datetime,'+isnull(''''+convert(varchar(200),StatusDate,121)+'''','NULL')+',121),)' FROM Authorizations
	--SET @stringData=@stringData+'''convert(money,''''''+isnull(cast('+@colName+' as varchar(200)),''0.0000'')+''''''),''+'
	SET @stringData=@stringData+'''convert(datetime,'+'''+isnull('''''+'''''+convert(varchar(200),'+@colName+',121)+'''''+''''',''NULL'')+'',121),''+'
  --                             'convert(datetime,'+isnull(''''+convert(varchar(200),StatusDate,121)+'''','NULL')+',121),)' FROM Authorizations
END
ELSE 
IF @dataType='image' 
BEGIN
	SET @stringData=@stringData+'''''''''+isnull(cast(convert(varbinary,'+@colName+') as varchar(6)),''0'')+'''''',''+'
END
ELSE --presuming the data type is int,bit,numeric,decimal 
BEGIN
	--SET @stringData=@stringData+'''''''''+isnull(cast('+@colName+' as varchar(200)),''0'')+'''''',''+'
	--SET @stringData=@stringData+'''convert(datetime,'+'''+isnull('''''+'''''+convert(varchar(200),'+@colName+',121)+'''''+''''',''NULL'')+'',121),''+'
	SET @stringData=@stringData+''''+'''+isnull('''''+'''''+convert(varchar(200),'+@colName+')+'''''+''''',''NULL'')+'',''+'
END

SET @string=@string+@colName+','

FETCH NEXT FROM cursCol INTO @colName,@dataType
END
DECLARE @Query nvarchar(4000)

SET @query ='SELECT '''+substring(@string,0,len(@string)) + ') VALUES(''+ ' + substring(@stringData,0,len(@stringData)-2)+'''+'')'' FROM '+@tableName
exec sp_executesql @query
--select @query

CLOSE cursCol
DEALLOCATE cursCol
GO
/****** Object:  Table [dbo].[LabourData]    Script Date: 10/20/2009 07:46:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabourData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] NOT NULL,
	[Rate] [float] NOT NULL,
	[NumberOfLabour] [float] NOT NULL,
 CONSTRAINT [PK_LabourData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoundCriteria]    Script Date: 10/20/2009 07:47:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoundCriteria](
	[Id] [int] NOT NULL,
	[RoundCategoryId] [int] NOT NULL,
	[SegmentTypeId] [int] NOT NULL,
	[Performance] [float] NOT NULL,
	[Size] [float] NOT NULL,
 CONSTRAINT [PK_RoundCriteria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SegmentMarketDemand]    Script Date: 10/20/2009 07:47:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SegmentMarketDemand](
	[Id] [int] NOT NULL,
	[RoundCategoryId] [int] NOT NULL,
	[SegmentTypeId] [int] NOT NULL,
	[Quantity] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Round]    Script Date: 10/20/2009 07:47:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Round](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamGameId] [int] NOT NULL,
	[RoundCategoryId] [int] NOT NULL,
	[Current] [bit] NOT NULL,
 CONSTRAINT [PK_Round] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamUser]    Script Date: 10/20/2009 07:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_TeamUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 10/20/2009 07:48:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 10/20/2009 07:46:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[Id] [int] NOT NULL,
	[TeamCategoryId] [int] NOT NULL,
	[SegmentTypeId] [int] NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RoundProduct]    Script Date: 10/20/2009 07:47:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoundProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoundId] [int] NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[SegmentTypeId] [int] NOT NULL,
 CONSTRAINT [PK_GameProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GameCriteria]    Script Date: 10/20/2009 07:46:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameCriteria](
	[SegmentTypeId] [int] NOT NULL,
	[Age] [float] NOT NULL,
	[AgeDecision] [float] NOT NULL,
	[TopPrice] [float] NOT NULL,
	[BottomPrice] [float] NOT NULL,
	[PriceDecision] [float] NOT NULL,
	[Performance] [float] NOT NULL,
	[Size] [float] NOT NULL,
	[PerformanceDecision] [float] NOT NULL,
	[TopReliability] [float] NOT NULL,
	[BottomReliability] [float] NOT NULL,
	[ReliabilityDecision] [float] NOT NULL,
 CONSTRAINT [PK_GameCriteria] PRIMARY KEY CLUSTERED 
(
	[SegmentTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamGame]    Script Date: 10/20/2009 07:47:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamGame](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GameId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_TeamGame] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SegmentType]    Script Date: 10/20/2009 07:47:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SegmentType](
	[Id] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SegmentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Team]    Script Date: 10/20/2009 07:47:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TeamCategoryId] [int] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FinanceData]    Script Date: 10/20/2009 07:45:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FinanceData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoundId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[Cash] [float] NOT NULL,
	[LongTermLoad] [float] NOT NULL,
	[ShortTermLoad] [float] NOT NULL,
 CONSTRAINT [PK_FinanceData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductionData]    Script Date: 10/20/2009 07:46:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductionData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoundProductId] [int] NOT NULL,
	[Inventory] [float] NOT NULL,
	[ManufacturedQuantity] [float] NOT NULL,
	[Contribution] [float] NULL,
	[CurrentAutomation] [float] NOT NULL,
	[AutomationForNextRound] [float] NULL,
	[OldCapacity] [float] NOT NULL,
	[NewCapacity] [float] NULL,
	[PreviousNumberOfLabour] [float] NULL,
	[NumberOfLabour] [float] NULL,
 CONSTRAINT [PK_ProductionData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RnDData]    Script Date: 10/20/2009 07:47:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RnDData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoundProductId] [int] NOT NULL,
	[PreviousRevisionDate] [datetime] NOT NULL,
	[RevisionDate] [datetime] NULL,
	[PreviousAge] [float] NOT NULL,
	[Age] [float] NULL,
	[PreviousReliability] [float] NOT NULL,
	[Reliability] [float] NULL,
	[PreviousPerformance] [float] NOT NULL,
	[Performance] [float] NULL,
	[PreviousSize] [float] NOT NULL,
	[Size] [float] NULL,
	[RnDCost] [float] NULL,
 CONSTRAINT [PK_RnDData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MarketingData]    Script Date: 10/20/2009 07:46:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarketingData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoundProductId] [int] NOT NULL,
	[PreviousSaleExpense] [float] NOT NULL,
	[SalesExpense] [float] NULL,
	[PreviousMarketingExpense] [float] NOT NULL,
	[MarketingExpense] [float] NULL,
	[PreviousPrice] [float] NOT NULL,
	[Price] [float] NULL,
	[PreviousForecastingQuantity] [float] NOT NULL,
	[ForecastingQuantity] [float] NULL,
	[PurchasedQuantity] [float] NULL,
	[Rating] [float] NULL,
	[Purchased] [bit] NOT NULL,
 CONSTRAINT [PK_MarketingData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductsAvailablePerRound]    Script Date: 10/20/2009 07:46:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsAvailablePerRound](
	[Id] [int] NOT NULL,
	[RoundProductId] [int] NOT NULL,
	[Quantity] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_FinanceData_Round]    Script Date: 10/20/2009 07:46:00 ******/
ALTER TABLE [dbo].[FinanceData]  WITH CHECK ADD  CONSTRAINT [FK_FinanceData_Round] FOREIGN KEY([RoundId])
REFERENCES [dbo].[Round] ([Id])
GO
ALTER TABLE [dbo].[FinanceData] CHECK CONSTRAINT [FK_FinanceData_Round]
GO
/****** Object:  ForeignKey [FK_GameCriteria_SegmentType]    Script Date: 10/20/2009 07:46:14 ******/
ALTER TABLE [dbo].[GameCriteria]  WITH CHECK ADD  CONSTRAINT [FK_GameCriteria_SegmentType] FOREIGN KEY([SegmentTypeId])
REFERENCES [dbo].[SegmentType] ([Id])
GO
ALTER TABLE [dbo].[GameCriteria] CHECK CONSTRAINT [FK_GameCriteria_SegmentType]
GO
/****** Object:  ForeignKey [FK_MarketingData_RoundProduct]    Script Date: 10/20/2009 07:46:42 ******/
ALTER TABLE [dbo].[MarketingData]  WITH CHECK ADD  CONSTRAINT [FK_MarketingData_RoundProduct] FOREIGN KEY([RoundProductId])
REFERENCES [dbo].[RoundProduct] ([Id])
GO
ALTER TABLE [dbo].[MarketingData] CHECK CONSTRAINT [FK_MarketingData_RoundProduct]
GO
/****** Object:  ForeignKey [FK_ProductCategory_SegmentType]    Script Date: 10/20/2009 07:46:47 ******/
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_SegmentType] FOREIGN KEY([SegmentTypeId])
REFERENCES [dbo].[SegmentType] ([Id])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_SegmentType]
GO
/****** Object:  ForeignKey [FK_ProductCategory_TeamCategory]    Script Date: 10/20/2009 07:46:47 ******/
ALTER TABLE [dbo].[ProductCategory]  WITH CHECK ADD  CONSTRAINT [FK_ProductCategory_TeamCategory] FOREIGN KEY([TeamCategoryId])
REFERENCES [dbo].[TeamCategory] ([Id])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_TeamCategory]
GO
/****** Object:  ForeignKey [FK_ProductionData_RoundProduct]    Script Date: 10/20/2009 07:46:57 ******/
ALTER TABLE [dbo].[ProductionData]  WITH CHECK ADD  CONSTRAINT [FK_ProductionData_RoundProduct] FOREIGN KEY([RoundProductId])
REFERENCES [dbo].[RoundProduct] ([Id])
GO
ALTER TABLE [dbo].[ProductionData] CHECK CONSTRAINT [FK_ProductionData_RoundProduct]
GO
/****** Object:  ForeignKey [FK_ProductsAvailablePerRound_RoundProduct]    Script Date: 10/20/2009 07:47:00 ******/
ALTER TABLE [dbo].[ProductsAvailablePerRound]  WITH CHECK ADD  CONSTRAINT [FK_ProductsAvailablePerRound_RoundProduct] FOREIGN KEY([RoundProductId])
REFERENCES [dbo].[RoundProduct] ([Id])
GO
ALTER TABLE [dbo].[ProductsAvailablePerRound] CHECK CONSTRAINT [FK_ProductsAvailablePerRound_RoundProduct]
GO
/****** Object:  ForeignKey [FK_RnDData_RoundProduct]    Script Date: 10/20/2009 07:47:11 ******/
ALTER TABLE [dbo].[RnDData]  WITH CHECK ADD  CONSTRAINT [FK_RnDData_RoundProduct] FOREIGN KEY([RoundProductId])
REFERENCES [dbo].[RoundProduct] ([Id])
GO
ALTER TABLE [dbo].[RnDData] CHECK CONSTRAINT [FK_RnDData_RoundProduct]
GO
/****** Object:  ForeignKey [FK_Round_RoundCategory]    Script Date: 10/20/2009 07:47:18 ******/
ALTER TABLE [dbo].[Round]  WITH CHECK ADD  CONSTRAINT [FK_Round_RoundCategory] FOREIGN KEY([RoundCategoryId])
REFERENCES [dbo].[RoundCategory] ([Id])
GO
ALTER TABLE [dbo].[Round] CHECK CONSTRAINT [FK_Round_RoundCategory]
GO
/****** Object:  ForeignKey [FK_Round_TeamGame]    Script Date: 10/20/2009 07:47:18 ******/
ALTER TABLE [dbo].[Round]  WITH CHECK ADD  CONSTRAINT [FK_Round_TeamGame] FOREIGN KEY([TeamGameId])
REFERENCES [dbo].[TeamGame] ([Id])
GO
ALTER TABLE [dbo].[Round] CHECK CONSTRAINT [FK_Round_TeamGame]
GO
/****** Object:  ForeignKey [FK_RoundCriteria_RoundCategory]    Script Date: 10/20/2009 07:47:26 ******/
ALTER TABLE [dbo].[RoundCriteria]  WITH CHECK ADD  CONSTRAINT [FK_RoundCriteria_RoundCategory] FOREIGN KEY([RoundCategoryId])
REFERENCES [dbo].[RoundCategory] ([Id])
GO
ALTER TABLE [dbo].[RoundCriteria] CHECK CONSTRAINT [FK_RoundCriteria_RoundCategory]
GO
/****** Object:  ForeignKey [FK_RoundCriteria_SegmentType]    Script Date: 10/20/2009 07:47:27 ******/
ALTER TABLE [dbo].[RoundCriteria]  WITH CHECK ADD  CONSTRAINT [FK_RoundCriteria_SegmentType] FOREIGN KEY([SegmentTypeId])
REFERENCES [dbo].[SegmentType] ([Id])
GO
ALTER TABLE [dbo].[RoundCriteria] CHECK CONSTRAINT [FK_RoundCriteria_SegmentType]
GO
/****** Object:  ForeignKey [FK_RoundCriteria_SegmentType1]    Script Date: 10/20/2009 07:47:27 ******/
ALTER TABLE [dbo].[RoundCriteria]  WITH CHECK ADD  CONSTRAINT [FK_RoundCriteria_SegmentType1] FOREIGN KEY([SegmentTypeId])
REFERENCES [dbo].[SegmentType] ([Id])
GO
ALTER TABLE [dbo].[RoundCriteria] CHECK CONSTRAINT [FK_RoundCriteria_SegmentType1]
GO
/****** Object:  ForeignKey [FK_RoundProduct_Round]    Script Date: 10/20/2009 07:47:31 ******/
ALTER TABLE [dbo].[RoundProduct]  WITH CHECK ADD  CONSTRAINT [FK_RoundProduct_Round] FOREIGN KEY([RoundId])
REFERENCES [dbo].[Round] ([Id])
GO
ALTER TABLE [dbo].[RoundProduct] CHECK CONSTRAINT [FK_RoundProduct_Round]
GO
/****** Object:  ForeignKey [FK_RoundProduct_SegmentType]    Script Date: 10/20/2009 07:47:31 ******/
ALTER TABLE [dbo].[RoundProduct]  WITH CHECK ADD  CONSTRAINT [FK_RoundProduct_SegmentType] FOREIGN KEY([SegmentTypeId])
REFERENCES [dbo].[SegmentType] ([Id])
GO
ALTER TABLE [dbo].[RoundProduct] CHECK CONSTRAINT [FK_RoundProduct_SegmentType]
GO
/****** Object:  ForeignKey [FK_MarketDemand_RoundCategory]    Script Date: 10/20/2009 07:47:35 ******/
ALTER TABLE [dbo].[SegmentMarketDemand]  WITH CHECK ADD  CONSTRAINT [FK_MarketDemand_RoundCategory] FOREIGN KEY([RoundCategoryId])
REFERENCES [dbo].[RoundCategory] ([Id])
GO
ALTER TABLE [dbo].[SegmentMarketDemand] CHECK CONSTRAINT [FK_MarketDemand_RoundCategory]
GO
/****** Object:  ForeignKey [FK_MarketDemand_SegmentType]    Script Date: 10/20/2009 07:47:35 ******/
ALTER TABLE [dbo].[SegmentMarketDemand]  WITH CHECK ADD  CONSTRAINT [FK_MarketDemand_SegmentType] FOREIGN KEY([SegmentTypeId])
REFERENCES [dbo].[SegmentType] ([Id])
GO
ALTER TABLE [dbo].[SegmentMarketDemand] CHECK CONSTRAINT [FK_MarketDemand_SegmentType]
GO
/****** Object:  ForeignKey [FK_SegmentType_GameInitialData]    Script Date: 10/20/2009 07:47:38 ******/
ALTER TABLE [dbo].[SegmentType]  WITH CHECK ADD  CONSTRAINT [FK_SegmentType_GameInitialData] FOREIGN KEY([Id])
REFERENCES [dbo].[GameInitialData] ([SegmentTypeId])
GO
ALTER TABLE [dbo].[SegmentType] CHECK CONSTRAINT [FK_SegmentType_GameInitialData]
GO
/****** Object:  ForeignKey [FK_Team_TeamCategory]    Script Date: 10/20/2009 07:47:42 ******/
ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_TeamCategory] FOREIGN KEY([TeamCategoryId])
REFERENCES [dbo].[TeamCategory] ([Id])
GO
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_TeamCategory]
GO
/****** Object:  ForeignKey [FK_TeamGame_Game]    Script Date: 10/20/2009 07:47:48 ******/
ALTER TABLE [dbo].[TeamGame]  WITH CHECK ADD  CONSTRAINT [FK_TeamGame_Game] FOREIGN KEY([GameId])
REFERENCES [dbo].[Game] ([Id])
GO
ALTER TABLE [dbo].[TeamGame] CHECK CONSTRAINT [FK_TeamGame_Game]
GO
/****** Object:  ForeignKey [FK_TeamGame_Team]    Script Date: 10/20/2009 07:47:49 ******/
ALTER TABLE [dbo].[TeamGame]  WITH CHECK ADD  CONSTRAINT [FK_TeamGame_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO
ALTER TABLE [dbo].[TeamGame] CHECK CONSTRAINT [FK_TeamGame_Team]
GO
/****** Object:  ForeignKey [FK_TeamUser_Team]    Script Date: 10/20/2009 07:47:52 ******/
ALTER TABLE [dbo].[TeamUser]  WITH CHECK ADD  CONSTRAINT [FK_TeamUser_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([Id])
GO
ALTER TABLE [dbo].[TeamUser] CHECK CONSTRAINT [FK_TeamUser_Team]
GO
/****** Object:  ForeignKey [FK_TeamUser_User]    Script Date: 10/20/2009 07:47:52 ******/
ALTER TABLE [dbo].[TeamUser]  WITH CHECK ADD  CONSTRAINT [FK_TeamUser_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserDetails] ([Id])
GO
ALTER TABLE [dbo].[TeamUser] CHECK CONSTRAINT [FK_TeamUser_User]
GO
/****** Object:  ForeignKey [FK_UserRole_Role]    Script Date: 10/20/2009 07:48:01 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[RoleDetails] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
/****** Object:  ForeignKey [FK_UserRole_User]    Script Date: 10/20/2009 07:48:01 ******/
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserDetails] ([Id])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User]
GO

/***********Create Init Script for RoundCriteria******************/
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('1','1','1','5.7','14.3')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('2','1','2','2.2','17.8')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('3','1','3','9.8','10.2')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('4','1','4','10.4','15.3')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('5','1','5','4.7','9.6')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('6','2','1','6.4','13.6')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('7','2','2','2.7','17.3')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('8','2','3','10.7','9.3')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('9','2','4','11.4','14.6')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('10','2','5','5.4','8.6')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('11','3','1','7.1','12.9')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('12','3','2','3.2','16.8')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('13','3','3','11.6','8.4')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('14','3','4','12.4','13.9')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('15','3','5','6.1','7.6')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('16','4','1','7.8','12.2')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('17','4','2','3.7','16.3')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('18','4','3','12.5','7.5')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('19','4','4','13.4','13.2')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('20','4','5','6.8','6.6')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('21','5','1','8.5','11.5')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('22','5','2','4.2','15.8')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('23','5','3','13.4','6.6')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('24','5','4','14.4','12.5')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('25','5','5','7.5','5.6')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('26','6','1','9.2','10.8')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('27','6','2','4.7','15.3')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('28','6','3','14.3','5.7')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('29','6','4','15.4','11.8')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('30','6','5','8.2','4.6')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('31','7','1','9.9','10.1')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('32','7','2','5.2','14.8')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('33','7','3','15.2','4.8')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('34','7','4','16.4','11.1')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('35','7','5','8.9','3.6')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('36','8','1','10.6','9.4')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('37','8','2','5.7','14.3')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('38','8','3','16.1','3.9')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('39','8','4','17.4','10.4')
INSERT RoundCriteria(Id,RoundCategoryId,SegmentTypeId,Performance,Size) VALUES('40','8','5','9.6','2.6')

/***********Create Init Script for GameCriteria******************/
INSERT GameCriteria(SegmentTypeId,Age,AgeDecision,TopPrice,BottomPrice,PriceDecision,Performance,Size,PerformanceDecision,TopReliability,BottomReliability,ReliabilityDecision) VALUES('1','2','0.47','30','20','0.23','5','15','0.21','14000','19000','0.9')
INSERT GameCriteria(SegmentTypeId,Age,AgeDecision,TopPrice,BottomPrice,PriceDecision,Performance,Size,PerformanceDecision,TopReliability,BottomReliability,ReliabilityDecision) VALUES('2','7','0.24','25','15','0.53','1.7','18.3','0.16','12000','17000','0.7')
INSERT GameCriteria(SegmentTypeId,Age,AgeDecision,TopPrice,BottomPrice,PriceDecision,Performance,Size,PerformanceDecision,TopReliability,BottomReliability,ReliabilityDecision) VALUES('3','0','0.29','40','30','0.09','8.9','11.1','0.43','20000','25000','0.19')
INSERT GameCriteria(SegmentTypeId,Age,AgeDecision,TopPrice,BottomPrice,PriceDecision,Performance,Size,PerformanceDecision,TopReliability,BottomReliability,ReliabilityDecision) VALUES('4','1','0.09','35','25','0.19','9.4','16','0.29','22000','27000','0.43')
INSERT GameCriteria(SegmentTypeId,Age,AgeDecision,TopPrice,BottomPrice,PriceDecision,Performance,Size,PerformanceDecision,TopReliability,BottomReliability,ReliabilityDecision) VALUES('5','1.5','0.29','35','25','0.09','4','10.6','0.43','16000','21000','0.19')

/***********Create Init Script for ConfigurationData******************/
INSERT ConfigurationData(Name,Value) VALUES('ReliabilityCost','2')
INSERT ConfigurationData(Name,Value) VALUES('PerformanceCost','500')
INSERT ConfigurationData(Name,Value) VALUES('SizeCost','500')
INSERT ConfigurationData(Name,Value) VALUES('ReliabilityFactor','1')
INSERT ConfigurationData(Name,Value) VALUES('PerformanceFactor','40')
INSERT ConfigurationData(Name,Value) VALUES('SizeFactor','40')
INSERT ConfigurationData(Name,Value) VALUES('AutomationCost','700')
INSERT ConfigurationData(Name,Value) VALUES('CapacityCost','700')
INSERT ConfigurationData(Name,Value) VALUES('LabourFactor','0.66')
INSERT ConfigurationData(Name,Value) VALUES('TaxRate','0.15')
INSERT ConfigurationData(Name,Value) VALUES('LongTermInterestRate','0.06')
INSERT ConfigurationData(Name,Value) VALUES('ShortTermInterestRate','0.06')

/***********Create Init Script for RoundCategory******************/
INSERT RoundCategory(Id,RoundName) VALUES('1','Round1')
INSERT RoundCategory(Id,RoundName) VALUES('2','Round2')
INSERT RoundCategory(Id,RoundName) VALUES('3','Round3')
INSERT RoundCategory(Id,RoundName) VALUES('4','Round4')
INSERT RoundCategory(Id,RoundName) VALUES('5','Round5')
INSERT RoundCategory(Id,RoundName) VALUES('6','Round6')
INSERT RoundCategory(Id,RoundName) VALUES('7','Round7')
INSERT RoundCategory(Id,RoundName) VALUES('8','Round8')

/***********Create Init Script for SegmentMarketDemand******************/
INSERT SegmentMarketDemand(Id,RoundCategoryId,SegmentTypeId,Quantity) VALUES('1','1','1','5000')
INSERT SegmentMarketDemand(Id,RoundCategoryId,SegmentTypeId,Quantity) VALUES('2','1','2','9000')
INSERT SegmentMarketDemand(Id,RoundCategoryId,SegmentTypeId,Quantity) VALUES('3','1','3','3000')
INSERT SegmentMarketDemand(Id,RoundCategoryId,SegmentTypeId,Quantity) VALUES('4','1','4','3000')
INSERT SegmentMarketDemand(Id,RoundCategoryId,SegmentTypeId,Quantity) VALUES('5','1','5','3000')

/***********Create Init Script for SegmentType******************/
INSERT SegmentType(Id,Description) VALUES('1','Traditional')
INSERT SegmentType(Id,Description) VALUES('2','Low')
INSERT SegmentType(Id,Description) VALUES('3','High')
INSERT SegmentType(Id,Description) VALUES('4','Performance')
INSERT SegmentType(Id,Description) VALUES('5','Size')

/***********Create Init Script for GameInitialData******************/
INSERT GameInitialData(SegmentTyoeId,UnitSold,UnitInventory,RevisionDate,AgeDec31,Reliability,Performance,Size,Price,MaterialCost,LabourCost,Overtime,AutomationForNextRound,CapacityForNextRound,PlantUtilization) VALUES('1','999','189',convert(datetime,'2006-11-21 00:00:00.000',121),'3.1','17500','5.5','14.5','28','11.59','7.49','0','4','1800','0.66')
INSERT GameInitialData(SegmentTyoeId,UnitSold,UnitInventory,RevisionDate,AgeDec31,Reliability,Performance,Size,Price,MaterialCost,LabourCost,Overtime,AutomationForNextRound,CapacityForNextRound,PlantUtilization) VALUES('2','1763','39',convert(datetime,'2005-05-25 00:00:00.000',121),'4.6','14000','3','17','21','7.81','7.12','0.3','5','1400','1.29')
INSERT GameInitialData(SegmentTyoeId,UnitSold,UnitInventory,RevisionDate,AgeDec31,Reliability,Performance,Size,Price,MaterialCost,LabourCost,Overtime,AutomationForNextRound,CapacityForNextRound,PlantUtilization) VALUES('3','366','40',convert(datetime,'2008-04-17 00:00:00.000',121),'1.7','23000','8','12','38','15.98','8.57','0','3','900','0.45')
INSERT GameInitialData(SegmentTyoeId,UnitSold,UnitInventory,RevisionDate,AgeDec31,Reliability,Performance,Size,Price,MaterialCost,LabourCost,Overtime,AutomationForNextRound,CapacityForNextRound,PlantUtilization) VALUES('4','358','78',convert(datetime,'2007-06-30 00:00:00.000',121),'2.5','25000','9.4','15.5','33','15.57','8.57','0','3','600','0.73')
INSERT GameInitialData(SegmentTyoeId,UnitSold,UnitInventory,RevisionDate,AgeDec31,Reliability,Performance,Size,Price,MaterialCost,LabourCost,Overtime,AutomationForNextRound,CapacityForNextRound,PlantUtilization) VALUES('5','314','62',convert(datetime,'2007-05-25 00:00:00.000',121),'2.6','19000','4','11','33','13.62','8.57','0','3','600','0.63')

/***********Create Init Script for TeamCategory******************/
INSERT TeamCategory(Id,Name) VALUES('1','Andrews')
INSERT TeamCategory(Id,Name) VALUES('2','Boldwins')
INSERT TeamCategory(Id,Name) VALUES('3','Chester')
INSERT TeamCategory(Id,Name) VALUES('4','Digbie')
INSERT TeamCategory(Id,Name) VALUES('5','Errie')
INSERT TeamCategory(Id,Name) VALUES('6','Ferris')

/***********Create Init Script for ProductCategory******************/
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('1','1','1','Able')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('2','1','2','Agape')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('3','1','3','Ace')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('4','1','4','Aid')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('5','1','5','Astra')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('6','2','1','Bit')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('7','2','2','Big')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('8','2','3','Binge')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('9','2','4','Bick')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('10','2','5','Blip')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('11','3','1','Chip')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('12','3','2','Coke')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('13','3','3','Cam')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('14','3','4','Cake')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('15','3','5','Cad')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('16','4','1','Drupal')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('17','4','2','Duke')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('18','4','3','Dom')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('19','4','4','Dame')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('20','4','5','Dart')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('21','5','1','Eb')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('22','5','2','El')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('23','5','3','Ed')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('24','5','4','Ek')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('25','5','5','Eel')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('26','6','1','Fist')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('27','6','2','Feel')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('28','6','3','Fact')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('29','6','4','Fig')
INSERT ProductCategory(Id,TeamCategoryId,SegmentTypeId,ProductName) VALUES('30','6','5','Fake')