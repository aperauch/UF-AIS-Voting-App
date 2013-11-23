CREATE TABLE [dbo].[Login_Details](
	[UFID] [varchar](10) NOT NULL,
	[Password] [varchar](15) NOT NULL
	PRIMARY KEY(UFID)
)

CREATE TABLE [dbo].[AIS_Members](
	[UFID] [varchar](10) NOT NULL,
	[First_Name] [varchar](25) NOT NULL,
	[Last_Name] [varchar](25) NULL,
	[Email] [varchar](25) NOT NULL,
	[Phone] [varchar](10) NULL,
	[Membership_Type] [varchar](10) NULL,
	[Paid_Membership_Fees] [varchar](10) NULL,
	[Voted] [varchar](10) NULL,
	PRIMARY KEY(UFID),
	FOREIGN KEY(UFID) REFERENCES Login_Details(UFID) ON DELETE CASCADE
)

CREATE TABLE [dbo].[Vote_Bank](
	[Voters_UFID] [varchar](10) NOT NULL,
	[Candidates_UFID] [varchar](10) NOT NULL,
	[Position] [varchar](25) NOT NULL
) 

CREATE TABLE [dbo].[Voting_Activation](
	[Position_ID] [int] IDENTITY(1,1) NOT NULL,
	[Position] [varchar](25) NOT NULL,
	[Activated] [varchar](10) NULL
)

CREATE TABLE [dbo].[Voting_Candidate](
	[UFID] [varchar](10) NOT NULL,
	[Position] [varchar](25) NULL,
	[No_of_Votes] [int] NULL,
	PRIMARY KEY(UFID),
	FOREIGN KEY(UFID) REFERENCES Login_Details(UFID) ON DELETE CASCADE
) 


INSERT INTO [Login_Details] VALUES ('00000000', 'admin')
INSERT INTO [Login_Details] VALUES ('11111111', 'president')
INSERT INTO [Login_Details] VALUES ('22222222', 'member')

INSERT INTO [AIS_Members] VALUES ('00000000' ,'AIS' ,'Admin' ,'admin@ufais.com' ,'3521234567' ,'admin' ,'Yes','No')
INSERT INTO [AIS_Members] VALUES ('11111111' ,'AIS' ,'President' ,'president@ufais.com' ,'3521234567' ,'president' ,'Yes','No')
INSERT INTO [AIS_Members] VALUES ('22222222' ,'Joe' ,'Smith' ,'member@ufl.edu' ,'3521234567' ,'member' ,'Yes','No')
