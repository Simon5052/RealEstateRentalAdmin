CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE "PropertyType"(
	"PropertyTypeId" SERIAL PRIMARY KEY NOT NULL,
    "PropertyTypeUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
    "PropertyTypeName" CHARACTER VARYING NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );

CREATE TABLE "Agent"(
	"AgentId" BIGSERIAL PRIMARY KEY NOT NULL,
	"AgentUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
    "FirstName" CHARACTER VARYING NOT NULL,
    "LastName" CHARACTER VARYING NOT NULL,
    "CompanyName" CHARACTER VARYING NOT NULL,
    "Email" CHARACTER VARYING NOT NULL,
    "PhoneNumber" CHARACTER VARYING NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );

CREATE TABLE "Region"(
	"RegionId" SERIAL PRIMARY KEY NOT NULL,
    "RegionUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
    "RegionName" CHARACTER VARYING NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );

CREATE TABLE "Rental"(
	"RentalId" BIGSERIAL PRIMARY KEY NOT NULL,
    "RentalUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
    "AgentId" INTEGER ,
    "CustomerId" INTEGER NOT NULL,
    "DateRented" TIMESTAMP WITHOUT TIME ZONE DEFAULT NOW() NOT NULL,
    "DueDate" TIMESTAMP NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );

CREATE TABLE "Customer"(
	"CustomerId" BIGSERIAL PRIMARY KEY NOT NULL,
	"CustomerUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
	"FirstName" CHARACTER VARYING NOT NULL,
    "LastName" CHARACTER VARYING NOT NULL,
    "Email" CHARACTER VARYING,
    "PhoneNumber" CHARACTER VARYING NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );

CREATE TABLE "Property"(
	"PropertyId" BIGSERIAL PRIMARY KEY NOT NULL,
	"PropertyUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
	"PropertytName" CHARACTER VARYING NOT NULL,
    "PropertyTypeId" INTEGER NOT NULL,
    "LocationId" INTEGER NOT NULL,
    "Space" INTEGER NOT NULL,
    "Rooms" INTEGER NOT NULL,
    "Cost" DOUBLE PRECISION DEFAULT 0 NOT NULL,
    "CreatedAt" TIMESTAMP WITHOUT TIME ZONE DEFAULT NOW() NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );
CREATE TABLE "Location"(
	"LocationId" SERIAL PRIMARY KEY NOT NULL,
    "LocationUuid" UUID UNIQUE DEFAULT uuid_generate_v4() NOT NULL,
    "Address" CHARACTER VARYING NOT NULL,
    "RegionId" INTEGER NOT NULL,
    "Active" BOOL DEFAULT TRUE NOT NULL
    );
