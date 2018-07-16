CREATE VIEW [dbo].[SeniorPlayerWithSkillDelta] AS (
SELECT [sp].[Id]
     , [sp].[HattrickId]
     , [sp].[FirstName]
     , [sp].[NickName]
     , [sp].[LastName]
     , [sp].[Age]
     , [sp].[HasHomegrownBonus]
     , [sp].[Agreeability]
     , [sp].[Aggressiveness]
     , [sp].[Honesty]
     , [sp].[Leadership]
     , [sp].[Specialty]
     , [sp].[Wage]
     , [sp].[CareerGoals]
     , [sp].[CareerHattricks]
     , [sp].[BookingStatus]
     , [sp].[InjuryStatus]
     , [sp].[PlaysOnNationalTeam]
     , [sp].[IsOnTransferMarket]
     , [sp].[MatchesOnSeniorNationalTeam]
     , [sp].[MatchesOnJuniorNationalTeam]
     , [sp].[Category]
     , [sp].[CountryId]
     , [spsd].[Form]
     , [spsd].[Stamina]
     , [spsd].[Keeper]
     , [spsd].[Defending]
     , [spsd].[Playmaking]
     , [spsd].[Winger]
     , [spsd].[Passing]
     , [spsd].[Scoring]
     , [spsd].[SetPieces]
     , [spsd].[Loyalty]
     , [spsd].[Experience]
     , [spsd].[TotalSkillIndex]
     , NULLIF([spsd].[FormDelta], 0) AS [FormDelta]
     , NULLIF([spsd].[StaminaDelta], 0) AS [StaminaDelta]
     , NULLIF([spsd].[KeeperDelta], 0) AS [KeeperDelta]
     , NULLIF([spsd].[DefendingDelta], 0) AS [DefendingDelta]
     , NULLIF([spsd].[PlaymakingDelta], 0) AS [PlaymakingDelta]
     , NULLIF([spsd].[WingerDelta], 0) AS [WingerDelta]
     , NULLIF([spsd].[PassingDelta], 0) AS [PassingDelta]
     , NULLIF([spsd].[ScoringDelta], 0) AS [ScoringDelta]
     , NULLIF([spsd].[SetPiecesDelta], 0) AS [SetPiecesDelta]
     , NULLIF([spsd].[LoyaltyDelta], 0) AS [LoyaltyDelta]
     , NULLIF([spsd].[ExperienceDelta], 0) AS [ExperienceDelta]
     , NULLIF([spsd].[TotalSkillIndexDelta], 0) AS [TotalSkillIndexDelta]
  FROM (SELECT [spsr].[Form]
             , [spsr].[Form] - LAG([spsr].[Form], 1) OVER (PARTITION BY [spsr].[SeniorPlayerId] ORDER BY [spsr].[SeniorPlayerId], [spsr].[RowNum] DESC) [FormDelta]
             , [spsr].[Stamina]
             , [spsr].[Stamina] - LAG([spsr].[Stamina], 1) OVER (PARTITION BY [spsr].[SeniorPlayerId] ORDER BY [spsr].[SeniorPlayerId], [spsr].[RowNum] DESC) [StaminaDelta]
             , [spsr].[Keeper]
             , [spsr].[Keeper] - LAG([spsr].[Keeper], 1) OVER (PARTITION BY [spsr].[SeniorPlayerId] ORDER BY [spsr].[SeniorPlayerId], [spsr].[RowNum] DESC) [KeeperDelta]
             , [spsr].[Defending]
             , [spsr].[Defending] - LAG([spsr].[Defending], 1) OVER (PARTITION BY [spsr].[SeniorPlayerId] ORDER BY [spsr].[SeniorPlayerId], [spsr].[RowNum] DESC) [DefendingDelta]
             , [spsr].[Playmaking]
             , [spsr].[Playmaking] - LAG([spsr].[Playmaking], 1) OVER (PARTITION BY [spsr].[SeniorPlayerId] ORDER BY [spsr].[SeniorPlayerId], [spsr].[RowNum] DESC) [PlaymakingDelta]
             , [spsr].[Winger]
             , [spsr].[Winger] - LAG([spsr].[Winger], 1) OVER (PARTITION BY [spsr].[SeniorPlayerId] ORDER BY [spsr].[SeniorPlayerId], [spsr].[RowNum] DESC) [WingerDelta]
             , [spsr].[Passing]
             , [spsr].[Passing] - LAG([spsr].[Passing], 1) OVER (PARTITION BY [spsr].[SeniorPlayerId] ORDER BY [spsr].[SeniorPlayerId], [spsr].[RowNum] DESC) [PassingDelta]
             , [spsr].[Scoring]
             , [spsr].[Scoring] - LAG([spsr].[Scoring], 1) OVER (PARTITION BY [spsr].[SeniorPlayerId] ORDER BY [spsr].[SeniorPlayerId], [spsr].[RowNum] DESC) [ScoringDelta]
             , [spsr].[SetPieces]
             , [spsr].[SetPieces] - LAG([spsr].[SetPieces], 1) OVER (PARTITION BY [spsr].[SeniorPlayerId] ORDER BY [spsr].[SeniorPlayerId], [spsr].[RowNum] DESC) [SetPiecesDelta]
             , [spsr].[Loyalty]
             , [spsr].[Loyalty] - LAG([spsr].[Loyalty], 1) OVER (PARTITION BY [spsr].[SeniorPlayerId] ORDER BY [spsr].[SeniorPlayerId], [spsr].[RowNum] DESC) [LoyaltyDelta]
             , [spsr].[Experience]
             , [spsr].[Experience] - LAG([spsr].[Experience], 1) OVER (PARTITION BY [spsr].[SeniorPlayerId] ORDER BY [spsr].[SeniorPlayerId], [spsr].[RowNum] DESC) [ExperienceDelta]
             , [spsr].[TotalSkillIndex]
             , [spsr].[TotalSkillIndex] - LAG([spsr].[TotalSkillIndex], 1) OVER (PARTITION BY [spsr].[SeniorPlayerId] ORDER BY [spsr].[SeniorPlayerId], [spsr].[RowNum] DESC) [TotalSkillIndexDelta]
             , [spsr].[SeniorPlayerId]
             , [spsr].[RowNum]
          FROM (SELECT CAST([sps].[Form] as INT) [Form]
                     , CAST([sps].[Stamina] as INT) [Stamina]
                     , CAST([sps].[Keeper] as INT) [Keeper]
                     , CAST([sps].[Defending] as INT) [Defending]
                     , CAST([sps].[Playmaking] as INT) [Playmaking]
                     , CAST([sps].[Winger] as INT) [Winger]
                     , CAST([sps].[Passing] as INT) [Passing]
                     , CAST([sps].[Scoring] as INT) [Scoring]
                     , CAST([sps].[SetPieces] as INT) [SetPieces]
                     , CAST([sps].[Loyalty] as INT) [Loyalty]
                     , CAST([sps].[Experience] as INT) [Experience]
                     , CAST([sps].[TotalSkillIndex] as INT) [TotalSkillIndex]
                     , [sps].[SeniorPlayerId]
                     , ROW_NUMBER() OVER (PARTITION BY [sps].[SeniorPlayerId] ORDER BY [sps].[UpdatedOn] DESC) AS [RowNum]
                  FROM [dbo].[SeniorPlayerSkills] [sps]) AS [spsr]) AS [spsd]
 INNER
  JOIN [dbo].[SeniorPlayer] [sp]
    ON [sp].[Id] = [spsd].[SeniorPlayerId]
 WHERE [spsd].[RowNum] = 1)