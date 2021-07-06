using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Configuration;
using CommonLib.Toolsets;
using DatabaseLib.Entities;
using DatabaseLib.Entities.GenericEntities;
using DatabaseLib.Entities.NodeMonEntities;
using NodeMonitor.Business;
using Serilog;

namespace NodeMonitor.Models
{
    // Um eine neu Migration auszuführen:
    // Add-Migration CreateDB -Project NodeMonitor -StartupProject NodeMonitor

    // Um die letzte Migration zu löschen:    
    // Remove-Migration -Project NodeMonitor -StartupProject NodeMonitor

    // Um die Datenbank zu erstellen oder upzudaten
    // Update-Database -Project NodeMonitor -StartupProject NodeMonitor

    // Bei Fehlermeldung:
    // "The migration '20200608204610_CreateDB' has already been applied to the database. Revert it and try again.
    // If the migration has been applied to other databases, consider reverting its changes using a new migration."
    //
    // Befehele:
    // update-database 0
    // Add-Migration CreateDB -Project NodeMonitor -StartupProject NodeMonitor

    public class nmDBContext : DbContext
    {
        #region DbSets
        public DbSet<NodeEntity> Nodes { get; set; }
        public DbSet<NodeLocationEntity> NodeLocations { get; set; }
        public DbSet<ReservedResourcesEntity> ReservedResources{ get; set; }
        public DbSet<TotalResourcesEntity> TotalResources { get; set; }
        public DbSet<UsedResourcesEntity> UsedResources { get; set; }
        public DbSet<ReservedResourcesHistoryEntity> ReservedResourcesHistories { get; set; }
        public DbSet<TotalResourcesHistoryEntity> TotalResourcesHistories { get; set; }
        public DbSet<UsedResourcesHistoryEntity> UsedResourcesHistories { get; set; }
        public DbSet<PublicConfigEntity> PublicConfigs { get; set; }
        public DbSet<WorkloadsEntity> Workloads { get; set; }
        public DbSet<IfaceEntity> Interfaces { get; set; }
        public DbSet<FarmEntity> Farms { get; set; }
        public DbSet<FarmLocationEntity> FarmLocations { get; set; }
        public DbSet<WalletAddressEntity> WalletAddresses { get; set; }
        public DbSet<ResourcePriceEntity> ResourcePrices { get; set; }
        public DbSet<NodeHistoryEntity> NodeHistories { get; set; }
        public DbSet<SettingsEntity> Settings { get; set; }
        public DbSet<TokenHistoryEntity> TokenHistories { get; set; }
        public DbSet<FarmerEntity> Farmers { get; set; }
        public DbSet<ThreefoldApiUriEntity> ThreefoldApiUris { get; set; }
        public DbSet<AbonementSourceTypEntity> AbonementSourceTypes { get; set; }
        public DbSet<AbonementsToSourcesEntity> AbonementsToSources { get; set; }
        public DbSet<AbonementTargetTypEntity> AbonementTargetTypes { get; set; }
        public DbSet<SchedulesEntity> Schedules { get; set; }
        public DbSet<SchedulesToDaysEntity> SchedulesToDays { get; set; }
        public DbSet<ScheduleDaysEntity> ScheduleDays { get; set; }
        public DbSet<ScheduleTaskEntity> ScheduleTasks { get; set; }
        public DbSet<ScheduleTriggerEntity> ScheduleTriggers { get; set; }
        public DbSet<ScheduleTypEntity> ScheduleTypes { get; set; }
        public DbSet<ScheduleTaskTypEntity> ScheduleTaskTypes { get; set; }
        public DbSet<ScheduleTriggerTypEntity> ScheduleTriggerTypes { get; set; }
        public DbSet<SchedulesToUsersEntity> SchedulesToUsers { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserLocationEntity> UserLocations { get; set; }
        public DbSet<UserDeviceEntity> Devices { get; set; }
        public DbSet<DeviceTypEntity> DeviceTypes { get; set; }
        public DbSet<PrivilegeEntity> Privileges { get; set; }
        public DbSet<FunctionEntity> Functions { get; set; }


        #endregion
        #region overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string _connectionString = "data source=";
            //_connectionString = _connectionString + AppConfig.ReadSetting<string>("Database_Ip");
            //_connectionString = _connectionString + ",";
            //_connectionString = _connectionString + AppConfig.ReadSetting<int>("Database_Port");
            //_connectionString = _connectionString + ";";
            //_connectionString = _connectionString + "initial catalog=";
            //_connectionString = _connectionString + AppConfig.ReadSetting<string>("Database_Catalog");
            //_connectionString = _connectionString + ";";
            //_connectionString = _connectionString + "User ID=";
            //_connectionString = _connectionString + AppConfig.ReadSetting<string>("Database_User");
            //_connectionString = _connectionString + ";";
            //_connectionString = _connectionString + "Password=";
            //_connectionString = _connectionString + AppConfig.ReadSetting<string>("Database_Password");

            // bei Migration einkommentieren (überschreibt Connectionstrigng von AppSettings)
            _connectionString = "data source=10.0.0.10,1433;initial catalog=omniflow_services;User ID=SA;Password=Passw0rd";
            //_connectionString = AppConfig.ReadSetting<string>("Database_ConnectionString");
            //------------------------------

            Log.Information("Connection String = {}",_connectionString);
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // N:N for AbonementToSources
            modelBuilder.Entity<AbonementsToSourcesEntity>()
                .HasKey(a_s => new { a_s.AbonementEntityId, a_s.AbonementSourceTypEntityId });
            modelBuilder.Entity<AbonementsToSourcesEntity>()
                .HasOne(a_s => a_s.AbonementEntity)
                .WithMany(a => a.AbonementsToSources)
                .HasForeignKey(bc => bc.AbonementEntityId);
            modelBuilder.Entity<AbonementsToSourcesEntity>()
                .HasOne(a_s => a_s.AbonementSourceTyp)
                .WithMany(s => s.AbonementsToSources)
                .HasForeignKey(a_s => a_s.AbonementSourceTypEntityId);

            // N:N for SchedulesToDays
            modelBuilder.Entity<SchedulesToDaysEntity>()
                .HasKey(a_s => new { a_s.ScheduleTriggerEntityId, a_s.ScheduleDaysEntityId });
            modelBuilder.Entity<SchedulesToDaysEntity>()
                .HasOne(a_s => a_s.ScheduleTriggerEntity)
                .WithMany(a => a.SchedulesToDaysEntity)
                .HasForeignKey(bc => bc.ScheduleTriggerEntityId);
            modelBuilder.Entity<SchedulesToDaysEntity>()
                .HasOne(a_s => a_s.ScheduleDaysEntity)
                .WithMany(s => s.SchedulesToDaysEntity)
                .HasForeignKey(a_s => a_s.ScheduleDaysEntityId);

            // N:N for SchedulesToUsersEntity
            modelBuilder.Entity<SchedulesToUsersEntity>()
                .HasKey(s_u => new { s_u.SchedulesEntityId, s_u.UserEntityId });
            modelBuilder.Entity<SchedulesToUsersEntity>()
                .HasOne(s_u => s_u.SchedulesEntity)
                .WithMany(s => s.SchedulesToUsersEntity)
                .HasForeignKey(bc => bc.SchedulesEntityId);
            modelBuilder.Entity<SchedulesToUsersEntity>()
                .HasOne(s_u => s_u.UserEntity)
                .WithMany(u => u.SchedulesToUsersEntity)
                .HasForeignKey(s_u => s_u.UserEntityId);

            // Add default ScheduleDays
            modelBuilder.Entity<ScheduleDaysEntity>().HasData(
                new { ScheduleDaysEntityId = 1, Name = "Montag"},
                new { ScheduleDaysEntityId = 2, Name = "Dienstag"},
                new { ScheduleDaysEntityId = 3, Name = "Mittwoch"},
                new { ScheduleDaysEntityId = 4, Name = "Donnerstag"},
                new { ScheduleDaysEntityId = 5, Name = "Freitag"},
                new { ScheduleDaysEntityId = 6, Name = "Samstag"},
                new { ScheduleDaysEntityId = 7, Name = "Sonntag"}
                );

            modelBuilder.Entity<ScheduleTypEntity>().HasData(
                new { ScheduleTypEntityId = 1, Name = "Threefold" },
                new { ScheduleTypEntityId = 2, Name = "CryptoBot" },
                new { ScheduleTypEntityId = 3, Name = "Generic" }
                );

            modelBuilder.Entity<ScheduleTaskTypEntity>().HasData(
                new { ScheduleTaskTypEntityId = 1, Name = "WebApiRequest" },
                new { ScheduleTaskTypEntityId = 2, Name = "GrpcRequest" },
                new { ScheduleTaskTypEntityId = 3, Name = "DeleteData" },
                new { ScheduleTaskTypEntityId = 4, Name = "ExportData" },
                new { ScheduleTaskTypEntityId = 5, Name = "RunApp" },
                new { ScheduleTaskTypEntityId = 5, Name = "RunCommand" },
                new { ScheduleTaskTypEntityId = 6, Name = "empty" }
                );

            modelBuilder.Entity<ScheduleTriggerTypEntity>().HasData(
                new { ScheduleTriggerTypEntityId = 1, Name = "GotData" },
                new { ScheduleTriggerTypEntityId = 2, Name = "GotMessage" },
                new { ScheduleTriggerTypEntityId = 3, Name = "ShutOffEvent" },
                new { ScheduleTriggerTypEntityId = 4, Name = "ShutOnEvent" },
                new { ScheduleTriggerTypEntityId = 5, Name = "TimedEvent" },
                new { ScheduleTriggerTypEntityId = 6, Name = "LogEvent" }
                );

            modelBuilder.Entity<DeviceTypEntity>().HasData(
                new { DeviceTypEntityId = 1, Name = "Messenger" },
                new { DeviceTypEntityId = 2, Name = "Email" },
                new { DeviceTypEntityId = 3, Name = "Telephone" },
                new { DeviceTypEntityId = 4, Name = "WebUI" }
                );

            modelBuilder.Entity<PrivilegeEntity>().HasData(
                new { PrivilegeEntityId = 1, Name = "Admin" },
                new { PrivilegeEntityId = 2, Name = "Default" }
                );

            modelBuilder.Entity<UserEntity>().HasData(
                new {
                    UserEntityId = 1, 
                    Name = "admin",
                    Lastname = "admin",
                    Password = "admin",
                    Nickname = "admin",
                    BirthDate = new DateTime(2021,12,12),
                    Active = true,
                    PrivilegesEntityId = 1
                });


            // macht es möglich, dass per trennzeichen getrennte Listen in ein Datenfeld gespeichert werden.
            //var splitStringConverter = new ValueConverter
            //    
            //    <IEnumerable<string>, string>
            //    (
            //    v => string.Join("; ", v), 
            //    v => v.Split(new[] { ';' })
            //    );
            //
            //    modelBuilder
            //    .Entity<IfaceEntity>()
            //    .Property(nameof(IfaceEntity.SerializedListOfAddresses))
            //    .HasConversion(splitStringConverter);
        }

        #endregion

        /*
         <connectionStrings>
           <!-- Verbindungsparemter.bei Fehlern Kontrollieren-->
           <!--
           Network protocol codes
           NAME        NETWORK LIBRARY
           dbnmpntw Named Pipes
        dbmslpcn    Shared Memory(local machine connections only, might fail when moving to production...)
           dbmssocn Winsock TCP/IP
        dbmsspxn    SPX/IPX
        dbmsvinn    Banyan Vines
           dbmsrpcn Multi-Protocol(Windows RPC)
           dbmsadsn Apple Talk
        dbmsgnet    VIA
           -->
           <!-- Lokale Express Instanz:  Data Source =.\SQLExpress; Integrated Security = true; AttachDbFilename=C:\MyFolder\TaskMaster.mdf;User Instance = true;-->
           <!-- Trusted Verbindung:      Server=WIN16S-MSSQL; Database=TaskMaster; Trusted_Connection=True;-->
           <!-- Standard Verbindung:     Server=WIN16S-MSSQL; Database=TaskMaster; User Id = flow; Password=eistee;-->
           <!-- Instanz Verbindung:      Server=WIN16S-MSSQL\MSSQL$SQLEXPRESS\; Database=TaskMaster; User Id = flow; Password=eistee;-->
           <!-- Über IP-Adresse:         Data Source = 10.0.0.18,1433; Network Library = DBMSSOCN; Initial Catalog = TaskMaster; User ID = flow; Password=eistee;-->
           <!-- Über NamedPipe:         Data Source = 10.0.0.18,1433; Network Library = dbnmpntw; Initial Catalog = TaskMaster; User ID = flow; Password=eistee;-->
           <!-- <add name = "tmDBContext" connectionString="data source=WIN16S-MSSQL; initial catalog=TaskMaster; User ID=flow ; Password=eistee;" providerName="System.Data.SqlClient" /> -->
           <add name = "DBContext" connectionString="data source=10.0.0.10,1433; initial catalog=TaskMaster; User ID=SA ; Password=Pa$$word;" providerName="System.Data.SqlClient" />
         </connectionStrings>
           */
    }
}