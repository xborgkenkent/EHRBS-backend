# EHRBS-backend
![ehrbs-sqnc](https://github.com/user-attachments/assets/83992619-0c52-4f27-98ab-1128c5cea0fc)


![ehrbs-erd](https://github.com/user-attachments/assets/2a26983d-25e6-4f51-a456-745eea2e1c29)

[ehrbs-sqnc-pdf.pdf](https://github.com/user-attachments/files/18768314/ehrbs-sqnc-pdf.pdf)

[ehrbs-erd-pdf.pdf](https://github.com/user-attachments/files/18768306/ehrbs-erd-pdf.pdf)

# Database Schema

## Tenants
- **Id**: `UUID` (PK)
- **Name**: `VARCHAR`
- **Address**: `TEXT`
- **ContactEmail**: `VARCHAR`
- **CreatedAt**: `TIMESTAMP`

## Users
- **Id**: `UUID` (PK)
- **FullName**: `VARCHAR`
- **Email**: `VARCHAR`
- **PasswordHash**: `VARCHAR`
- **Role**: `ENUM`
- **TenantId**: `UUID` (FK)
- **CreatedAt**: `TIMESTAMP`

## Doctors
- **Id**: `UUID` (PK) _(FK to Users)_
- **Specialty**: `VARCHAR`
- **LicenseNumber**: `VARCHAR`
- **ConsultationFee**: `DECIMAL`
- **Availability**: `JSON`
- **ExperienceYears**: `INT`
- **TenantId**: `UUID` (FK)
- **CreatedAt**: `TIMESTAMP`

## Patients
- **Id**: `UUID` (PK) _(FK to Users)_
- **MedicalRecordNumber**: `VARCHAR`
- **DateOfBirth**: `DATE`
- **BloodType**: `VARCHAR`
- **EmergencyContact**: `VARCHAR`
- **InsuranceProvider**: `VARCHAR`
- **TenantId**: `UUID` (FK)
- **CreatedAt**: `TIMESTAMP`

## Admins
- **Id**: `UUID` (PK) _(FK to Users)_
- **TenantId**: `UUID` (FK)
- **Permissions**: `JSON`
- **CreatedAt**: `TIMESTAMP`

## Appointments
- **Id**: `UUID` (PK)
- **DoctorId**: `UUID` (FK)
- **PatientId**: `UUID` (FK)
- **ScheduledAt**: `TIMESTAMP`
- **Status**: `ENUM`
- **Notes**: `TEXT`
- **TenantId**: `UUID` (FK)
- **CreatedAt**: `TIMESTAMP`

## MedicalRecords
- **Id**: `UUID` (PK)
- **PatientId**: `UUID` (FK)
- **DoctorId**: `UUID` (FK)
- **RecordType**: `ENUM`
- **EncryptedData**: `TEXT`
- **EncryptionKey**: `VARCHAR`
- **TenantId**: `UUID` (FK)
- **CreatedAt**: `TIMESTAMP`

## Messages
- **Id**: `UUID` (PK)
- **SenderId**: `UUID` (FK)
- **ReceiverId**: `UUID` (FK)
- **EncryptedMessage**: `TEXT`
- **Timestamp**: `TIMESTAMP`
- **TenantId**: `UUID` (FK)

## Billing
- **Id**: `UUID` (PK)
- **PatientId**: `UUID` (FK)
- **DoctorId**: `UUID` (FK)
- **Amount**: `DECIMAL`
- **PaymentMethod**: `ENUM`
- **Status**: `ENUM`
- **InvoiceNumber**: `VARCHAR`
- **TenantId**: `UUID` (FK)
- **CreatedAt**: `TIMESTAMP`

## AuditLogs
- **Id**: `UUID` (PK)
- **UserId**: `UUID` (FK)
- **Action**: `VARCHAR`
- **TableAffected**: `VARCHAR`
- **RecordId**: `UUID`
- **Timestamp**: `TIMESTAMP`
- **TenantId**: `UUID` (FK)
