//-----------------------------------------------------------------------
// <copyright file="DatabaseUtils.cs" company="Hyperar">
//     Copyright (c) Hyperar. All rights reserved.
// </copyright>
// <author>Matías Ezequiel Sánchez</author>
//-----------------------------------------------------------------------
namespace Hyperar.HattrickUltimate.UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Provides Database utility functions.
    /// </summary>
    internal class DatabaseUtils
    {
        #region Private Fields

        /// <summary>
        /// Dot character.
        /// </summary>
        private const string Dot = ".";

        /// <summary>
        /// Microsoft SQL Server Local DB tool Instance command line argument.
        /// </summary>
        private const string InstanceArgument = "i";

        /// <summary>
        /// Left parenthesis.
        /// </summary>
        private const string LeftParenthesis = "(";

        /// <summary>
        /// Microsoft SQL Server Local DB tool executable name.
        /// </summary>
        private const string LocalDbTool = "sqllocaldb.exe";

        /// <summary>
        /// Environment variable 'PATH' name.
        /// </summary>
        private const string PathEnvironmentVariable = "PATH";

        /// <summary>
        /// Right parenthesis.
        /// </summary>
        private const string RightParenthesis = ")";

        /// <summary>
        /// Semicolon character.
        /// </summary>
        private const char Semicolon = ';';

        /// <summary>
        /// Microsoft SQL Server Local DB tool Version command line argument.
        /// </summary>
        private const string ServerArgument = "v";

        /// <summary>
        /// Space character.
        /// </summary>
        private const string Space = " ";

        /// <summary>
        /// Structured Query Language.
        /// </summary>
        private const string Sql = "sql";

        /// <summary>
        /// Version tag.
        /// </summary>
        private const string Version = "version";

        #endregion Private Fields

        #region Internal Methods

        /// <summary>
        /// Gets the best LocalDb instance found on the system.
        /// </summary>
        /// <returns>Then best LocalDb instance name.</returns>
        internal static string GetLocalDbInstance()
        {
            string instance = null;

            try
            {
                // Gets all the Microsoft SQL Server paths on the Environment Variable 'PATH'.
                var databaseServerPaths = Environment.GetEnvironmentVariable(PathEnvironmentVariable, EnvironmentVariableTarget.Machine)
                                                     .Split(new char[] { Semicolon }, StringSplitOptions.RemoveEmptyEntries)
                                                     .Where(value => value.IndexOf(Sql, StringComparison.OrdinalIgnoreCase) != -1)
                                                     .OrderByDescending(value => value)
                                                     .ToList();

                string latestLocalDatabaseServerPath = null;

                // Gets the latest version with the SQL Local DB tool.
                foreach (string curServer in databaseServerPaths)
                {
                    if (File.Exists(Path.Combine(curServer, LocalDbTool)))
                    {
                        latestLocalDatabaseServerPath = curServer;

                        break;
                    }
                }

                // If no elegible paths found, returns null.
                if (string.IsNullOrWhiteSpace(latestLocalDatabaseServerPath))
                {
                    return null;
                }

                int latestInstalledVersion = GetLocalDbServerGreatestVersionNumber(latestLocalDatabaseServerPath);

                instance = GetBestLocalDbInstance(latestLocalDatabaseServerPath, latestInstalledVersion);
            }
            catch
            {
                throw;
            }

            return instance;
        }

        #endregion Internal Methods

        #region Private Methods

        /// <summary>
        /// Gets the best LocalDb instance found.
        /// </summary>
        /// <param name="path">Path to the LocalDb tool.</param>
        /// <param name="desiredServerVersion">Desired version.</param>
        /// <returns>The name of the best LocalDb instance.</returns>
        private static string GetBestLocalDbInstance(string path, int desiredServerVersion)
        {
            List<string> instances;

            string desiredInstance = null;

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        Arguments = InstanceArgument,
                        CreateNoWindow = true,
                        FileName = $"{path}\\{LocalDbTool}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        WorkingDirectory = path
                    }
                };

                process.Start();
                process.WaitForExit();

                instances = new List<string>();

                while (!process.StandardOutput.EndOfStream)
                {
                    instances.Add(process.StandardOutput.ReadLine());
                }

                foreach (string instance in instances)
                {
                    if (!string.IsNullOrWhiteSpace(desiredInstance))
                    {
                        break;
                    }

                    process = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            Arguments = $"{InstanceArgument} \"{instance}\"",
                            CreateNoWindow = true,
                            FileName = $"{path}\\{LocalDbTool}",
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            WorkingDirectory = path
                        }
                    };

                    process.Start();
                    process.WaitForExit();

                    while (!process.StandardOutput.EndOfStream)
                    {
                        string outputLine = process.StandardOutput.ReadLine();

                        if (outputLine.StartsWith(Version, StringComparison.OrdinalIgnoreCase))
                        {
                            int startIndex = outputLine.LastIndexOf(Space) + 1;
                            int length = outputLine.Length - startIndex;
                            int version = Convert.ToInt32(outputLine.Substring(startIndex, length)
                                                                    .Replace(Dot, string.Empty));

                            if (desiredServerVersion.Equals(version))
                            {
                                desiredInstance = instance;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return desiredInstance;
        }

        /// <summary>
        /// Gets the LocalDb server greatest version number.
        /// </summary>
        /// <param name="path">Path to the LocalDb tool.</param>
        /// <returns>The LocalDb Server Greatest Version number.</returns>
        private static int GetLocalDbServerGreatestVersionNumber(string path)
        {
            List<int> versions;

            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        Arguments = ServerArgument,
                        CreateNoWindow = true,
                        FileName = $"{path}\\{LocalDbTool}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        WorkingDirectory = path
                    }
                };

                process.Start();
                process.WaitForExit();

                versions = new List<int>();

                while (!process.StandardOutput.EndOfStream)
                {
                    string outputLine = process.StandardOutput.ReadLine();

                    int startIndex = outputLine.LastIndexOf(LeftParenthesis) + 1;
                    int length = outputLine.LastIndexOf(RightParenthesis) - startIndex;
                    int version = Convert.ToInt32(outputLine.Substring(startIndex, length)
                                         .Replace(Dot, string.Empty));

                    versions.Add(version);
                }
            }
            catch
            {
                throw;
            }

            return versions.OrderByDescending(value => value)
                           .FirstOrDefault();
        }

        #endregion Private Methods
    }
}