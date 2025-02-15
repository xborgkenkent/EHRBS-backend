using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EHRBS_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    EncryptedMessage = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ContactEmail = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    TenantsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Tenants_TenantsId",
                        column: x => x.TenantsId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Specialty = table.Column<string>(type: "text", nullable: false),
                    LicenseNumber = table.Column<string>(type: "text", nullable: false),
                    ConsultationFee = table.Column<decimal>(type: "numeric", nullable: false),
                    Availability_Days = table.Column<string>(type: "text", nullable: false),
                    Availability_StartTime = table.Column<string>(type: "text", nullable: false),
                    Availability_EndTime = table.Column<string>(type: "text", nullable: false),
                    ExperienceYears = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantsId = table.Column<Guid>(type: "uuid", nullable: true),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Tenants_TenantsId",
                        column: x => x.TenantsId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicalRecordNumber = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    BloodType = table.Column<string>(type: "text", nullable: false),
                    EmergencyContact = table.Column<string>(type: "text", nullable: false),
                    InsuranceProvider = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TenantsId = table.Column<Guid>(type: "uuid", nullable: true),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Tenants_TenantsId",
                        column: x => x.TenantsId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Patients_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DoctorsId = table.Column<Guid>(type: "uuid", nullable: true),
                    PatientsId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Tenants_TenantsId",
                        column: x => x.TenantsId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Billings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PatienId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DoctorsId = table.Column<Guid>(type: "uuid", nullable: true),
                    PatientsId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Billings_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Billings_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Billings_Tenants_TenantsId",
                        column: x => x.TenantsId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordType = table.Column<int>(type: "integer", nullable: false),
                    EncryptedData = table.Column<string>(type: "text", nullable: false),
                    EncryptionKey = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DoctorsId = table.Column<Guid>(type: "uuid", nullable: true),
                    PatientsId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Tenants_TenantsId",
                        column: x => x.TenantsId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicalRecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: false),
                    TableAffected = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MedicalRecordsId = table.Column<Guid>(type: "uuid", nullable: true),
                    TenantsId = table.Column<Guid>(type: "uuid", nullable: true),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditLogs_MedicalRecords_MedicalRecordsId",
                        column: x => x.MedicalRecordsId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuditLogs_Tenants_TenantsId",
                        column: x => x.TenantsId,
                        principalTable: "Tenants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuditLogs_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorsId",
                table: "Appointments",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientsId",
                table: "Appointments",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TenantsId",
                table: "Appointments",
                column: "TenantsId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_MedicalRecordsId",
                table: "AuditLogs",
                column: "MedicalRecordsId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_TenantsId",
                table: "AuditLogs",
                column: "TenantsId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLogs_UsersId",
                table: "AuditLogs",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_DoctorsId",
                table: "Billings",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_PatientsId",
                table: "Billings",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Billings_TenantsId",
                table: "Billings",
                column: "TenantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_TenantsId",
                table: "Doctors",
                column: "TenantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UsersId",
                table: "Doctors",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_DoctorsId",
                table: "MedicalRecords",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientsId",
                table: "MedicalRecords",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_TenantsId",
                table: "MedicalRecords",
                column: "TenantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_TenantsId",
                table: "Patients",
                column: "TenantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UsersId",
                table: "Patients",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TenantsId",
                table: "Users",
                column: "TenantsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Billings");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
