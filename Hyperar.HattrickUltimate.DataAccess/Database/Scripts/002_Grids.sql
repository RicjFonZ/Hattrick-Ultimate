-- [app].[Grid]
IF NOT EXISTS (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid')
    INSERT INTO [app].[Grid] ([Name]) VALUES ('Main Window Senior Player Grid');

-- [app].[GridColumn]
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerId' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Id', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerHattrickId' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'HattrickId', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerFirstName' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'FirstName', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerNickName' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'NickName', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerLastName' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'LastName', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerAge' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Age', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerHasHomegrownBonus' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'HasHomegrownBonus', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerAgreeability' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Agreeability', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerAggressiveness' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Aggressiveness', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerHonesty' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Honesty', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerLeadership' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Leadership', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerSpecialty' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Specialty', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerWage' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Wage', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerCareerGoals' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'CareerGoals', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerCareerHattricks' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'CareerHattricks', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerBookingStatus' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'BookingStatus', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerInjuryStatus' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'InjuryStatus', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerPlaysOnNationalTeam' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'PlaysOnNationalTeam', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerIsOnTransferMarket' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'IsOnTransferMarket', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerMatchesOnSeniorNationalTeam' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'MatchesOnSeniorNationalTeam', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerMatchesOnJuniorNationalTeam' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'MatchesOnJuniorNationalTeam', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerCategory' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Category', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerCountryName' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'CountryName', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerCountryEnglishName' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'CountryEnglishName', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerForm' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Form', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerStamina' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Stamina', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerKeeper' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Keeper', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerDefending' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Defending', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerPlaymaking' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Playmaking', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerWinger' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Winger', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerPassing' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Passing', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerScoring' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Scoring', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerSetPieces' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'SetPieces', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerLoyalty' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Loyalty', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerExperience' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'Experience', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));
IF NOT EXISTS (SELECT [Id] FROM [app].[GridColumn] WHERE [Name] = 'ColumnSeniorPlayerTotalSkillIndex' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridColumn] ([Name], [DisplayProperty], [ValueProperty], [GridId]) VALUES ('ColumnSeniorPlayerId', NULL, 'TotalSkillIndex', (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));

-- [app].[GridLayout]
IF NOT EXISTS (SELECT [Id] FROM [app].[GridLayout] WHERE [Name] = 'Default Layout' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'))
    INSERT INTO [app].[GridLayout] ([Name], [IsDefault], [GridId]) VALUES ('Default Layout', 1, (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid'));

-- [app].[GridLayoutColumn]
IF NOT EXISTS (SELECT [Id] FROM [app].[GridLayoutColumn] WHERE [GridLayoutId] = (SELECT [Id] FROM [app].[GridLayout] WHERE [Name] = 'Default Layout' AND [GridId] = (SELECT [Id] FROM [app].[Grid] WHERE [Name] = 'Main Window Senior Player Grid')))
    INSERT INTO [app].[GridLayoutColumn] ([IsFixed], [GridColumnId], [GridLayoutId]) SELECT 0, [Id], (SELECT [gl].[Id] FROM [app].[GridLayout] [gl] INNER JOIN [app].[Grid] [g] ON [gl].[GridId] = [g].[Id] WHERE [g].[Name] = 'Main Window Senior Player Grid' AND [gl].[Name] = 'Default Layout') FROM [app].[GridColumn]