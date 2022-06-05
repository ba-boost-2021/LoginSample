﻿namespace LoginSample.Common;

public class Settings
{
    public DatabaseConfiguration Database { get; set; }
    public JwtConfiguration Jwt { get; set; }

    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
    }
    public class JwtConfiguration
    {
        public string Key { get; set; }
        public int Expires { get; set; }
    }
}
