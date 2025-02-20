# Encrypted Healthcare Records & Billing System

## Core Features

- **End-to-End Encryption (E2EE)** - Encrypt patient records, prescriptions, and communication
- **Secure User Authentication** -  Role-based access (Doctors, Patients, Admins)
- **Appointment Scheduling** - Encrypted booking system for consultations
- **Billing & Payment Processing** - Integrate Stripe, PayPal, or insurance claim handling
- **Compliance & Audit Logs** -  Ensure GDPR/HIPAA compliance
- **Prescription & Lab Reports** - Encrypted document storage & sharing
- **Multi-Tenant Support** - Clinics, hospitals, and independent doctors can use it

# Sequence Diagram
## Basic Flow
![ehrbs-sqnc-`](https://github.com/user-attachments/assets/04a9a634-53ee-443a-81c9-2ed78f09477c)
## Audit Logs Flow
![ehrbs-sequence-audit](https://github.com/user-attachments/assets/fb3aa216-30c7-4089-97b3-53dfbb6999a5)

# Entity Relationship Diagram
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

## HOW TO RUN
- **Using DockerfileDev**
- ***docker build -t ehrbs-dev -f Dockerfile.dev .***
- ***docker run -p 8080:80 -v $(pwd):/app ehrbs-dev***