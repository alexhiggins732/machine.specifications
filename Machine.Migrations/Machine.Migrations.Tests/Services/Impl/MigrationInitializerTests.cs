using System;
using System.Collections.Generic;

using Machine.Core;
using Machine.Migrations.DatabaseProviders;
using Machine.Migrations.SchemaProviders;

using NUnit.Framework;

namespace Machine.Migrations.Services.Impl
{
  [TestFixture]
  public class MigrationInitializerTests : StandardFixture<MigrationInitializer>
  {
    private IDatabaseProvider _databaseProvider;
    private ISchemaProvider _schemaProvider;
    private IDatabaseMigration _migration;

    public override MigrationInitializer Create()
    {
      _databaseProvider = _mocks.CreateMock<IDatabaseProvider>();
      _schemaProvider = _mocks.CreateMock<ISchemaProvider>();
      _migration = _mocks.CreateMock<IDatabaseMigration>();
      return new MigrationInitializer(_databaseProvider, _schemaProvider);
    }

    [Test]
    public void InitializeMigration_Always_CallsInitialize()
    {
      using (_mocks.Record())
      {
        _migration.Initialize(_databaseProvider, _schemaProvider);
      }
      _target.InitializeMigration(_migration);
      _mocks.VerifyAll();
    }
  }
}