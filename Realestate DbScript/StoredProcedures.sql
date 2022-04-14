--                              R  E  G  I O  N

create function "GetAllRegion"()
    returns TABLE("RegionUuid" uuid, "RegionName" character varying)
    language plpgsql
as
$$
BEGIN
   RETURN QUERY
   SELECT R."RegionUuid", R."RegionName"
      FROM "Region" R
      WHERE "Active" = TRUE;
   END
$$;

CREATE FUNCTION "DeleteRegion"("_regionUuid" UUID)
RETURNS CHARACTER VARYING
LANGUAGE plpgsql
AS $$
    BEGIN
        update "Region"
        SET "Active" = FALSE
        WHERE "RegionUuid" = "_regionUuid";

        RETURN  'Deleted';


    end

    $$;

               -- P R O P E R T Y   T Y P E

create OR REPLACE function "GetAllPropertyType"()
    returns TABLE("PropertyTypeId" int, "PropertyTypeUuid" UUID, "PropertTypeName" CHARACTER VARYING)
    language plpgsql
as
$$
BEGIN
   RETURN QUERY
   SELECT PT."PropertyTypeId", PT."PropertyTypeUuid", PT."PropertyTypeName"
      FROM "PropertyType" PT
      WHERE "Active" = TRUE;
   END
$$;

CREATE FUNCTION "DeletePropertyType"("_propertyTypeUuid" UUID)
RETURNS CHARACTER VARYING
LANGUAGE plpgsql
AS $$
    BEGIN
        update "PropertyType"
        SET "Active" = FALSE
        WHERE "PropertyTypeUuid" = "_propertyTypeUuid";

        RETURN  'Deleted';


    end

    $$;

CREATE FUNCTION "InsertPropertyType"("_propertyTypeName" CHARACTER VARYING)
RETURNS CHARACTER VARYING
LANGUAGE plpgsql
AS $$
    BEGIN
        INSERT INTO "PropertyType"("PropertyTypeName") VALUES ("_propertyTypeName");
        RETURN 'Added';
    END
    $$;


--                           L  O  C  A  T  I   O  N

create function "GetAllLocation"()
    returns TABLE( "LocationUuid" uuid, "Address" character varying, "RegionUud" uuid)
    language plpgsql
as
$$
BEGIN
   RETURN QUERY
   SELECT  L."LocationUuid", L   ."Address", R."RegionUuid"
      FROM "Location" L
   left join "Region" R
   on L."RegionId" = R."RegionId"
      WHERE L."Active" = TRUE;
   END
$$;

CREATE FUNCTION "DeleteLocation"("_locationUuid" UUID)
RETURNS CHARACTER VARYING
LANGUAGE plpgsql
AS $$
    BEGIN
        update "Location"
        SET "Active" = FALSE
        WHERE "LocationUuid" = "_locationUuid";

        RETURN  'Deleted';


    end

    $$;

CREATE FUNCTION "InsertLocation"("_address" CHARACTER VARYING, "_regionId" INTEGER)
RETURNS CHARACTER VARYING
LANGUAGE plpgsql
AS $$
    BEGIN
        INSERT INTO "Location"("Address", "RegionId") VALUES ("_address", "_regionId");
        RETURN 'Added';
    END
    $$;




DROP FUNCTION IF EXISTS "GetLocationByRegionUuid"();
create OR REPLACE function "GetLocationByRegionUuid"("_regionUuid" uuid)
    returns TABLE("LocationUuid" uuid,"Address" CHARACTER VARYING)
    language plpgsql
as
$$
BEGIN
   RETURN QUERY
   SELECT  L."LocationUuid",L."Address"
      FROM "Location" L
   left join "Region" R ON R."RegionId" = L."RegionId"


      WHERE R."RegionUuid" = "_regionUuid" ;
   END
$$;
--                             R  E  N  T  A  L

create OR REPLACE function "GetAllRental"()
    returns TABLE("RentalId" bigint, "RentalUuid" UUID, "AgentId" INTEGER, "CustomerId" INTEGER, "DateRented"
                 timestamp, "DateDue" timestamp)
    language plpgsql
as
$$
BEGIN
   RETURN QUERY
   SELECT R."RentalId", R."RentalUuid", R."AgentId", R."CustomerId", R."DateRented", R."DueDate"
      FROM "Rental" R
      WHERE "Active" = TRUE;
   END
$$;

CREATE FUNCTION "DeleteRental"("_rentalUuid" UUID)
RETURNS CHARACTER VARYING
LANGUAGE plpgsql
AS $$
    BEGIN
        update "Rental"
        SET "Active" = FALSE
        WHERE "RentalUuid" = "_rentalUuid";

        RETURN  'Deleted';


    end

    $$;

CREATE FUNCTION "InsertRental"("_agentId" INTEGER, "_customerId" INTEGER, "_dateRented" timestamp,
 "_dateDue" timestamp)
RETURNS CHARACTER VARYING
LANGUAGE plpgsql
AS $$
    BEGIN
        INSERT INTO "Rental"("AgentId", "CustomerId", "DateRented", "DueDate") VALUES ("_agentId", "_customerId",
            "_dateRented", "_dateDue");
        RETURN 'Added';
    END
    $$;


--                                             A  G  E  N  T

create OR REPLACE function "GetAllAgent"()
    returns TABLE("AgentId" bigint, "AgentUuid" UUID, "FirstName" CHARACTER VARYING, "LasttName" CHARACTER VARYING,
     "CompanyName" CHARACTER VARYING, "Email" CHARACTER VARYING, "PhoneNumber" CHARACTER VARYING)
    language plpgsql
as
$$
BEGIN
   RETURN QUERY
   SELECT A."AgentId", A."AgentUuid", A."FirstName", A."LastName", A."CompanyName", A."Email", A."PhoneNumber"
      FROM "Agent" A
      WHERE "Active" = TRUE;
   END
$$;

CREATE FUNCTION "DeleteAgent"("_agentUuid" UUID)
RETURNS CHARACTER VARYING
LANGUAGE plpgsql
AS $$
    BEGIN
        update "Agent"
        SET "Active" = FALSE
        WHERE "AgentUuid" = "_agentUuid";

        RETURN  'Deleted';


    end

    $$;

CREATE FUNCTION "InsertAgent"("_firstName" CHARACTER VARYING, "_lastName" CHARACTER VARYING, "_companyName" CHARACTER VARYING,
 "_email" CHARACTER VARYING, "_phoneNumber" CHARACTER VARYING)
RETURNS CHARACTER VARYING
LANGUAGE plpgsql
AS $$
    BEGIN
        INSERT INTO "Agent"("FirstName", "LastName", "CompanyName", "Email", "PhoneNumber") VALUES ("_firstName", "_lastName",
            "_companyName", "_email", "_phoneNumber");
        RETURN 'Added';
    END
    $$;


--                                     C  U  S  T  M  E  R

create OR REPLACE function "GetAllCustomer"()
    returns TABLE("CustomerId" bigint, "CustomerUuid" UUID, "FirstName" CHARACTER VARYING, "LastName" CHARACTER VARYING,
      "Email" CHARACTER VARYING, "PhoneNumber" CHARACTER VARYING)
    language plpgsql
as
$$
BEGIN
   RETURN QUERY
   SELECT C."CustomerId", C."CustomerUuid", C."FirstName", C."LastName", C."Email", C."PhoneNumber"
      FROM "Customer" C
      WHERE "Active" = TRUE;
   END
$$;

CREATE FUNCTION "DeleteCustomer"("_customerUuid" UUID)
RETURNS CHARACTER VARYING
LANGUAGE plpgsql
AS $$
    BEGIN
        update "Customer"
        SET "Active" = FALSE
        WHERE "CustomerUuid" = "_customerUuid";

        RETURN  'Deleted';


    end

    $$;

CREATE FUNCTION "InsertCustomer"("_firstName" CHARACTER VARYING, "_lastName" CHARACTER VARYING,
 "_email" CHARACTER VARYING, "_phoneNumber" CHARACTER VARYING)
RETURNS CHARACTER VARYING
LANGUAGE plpgsql
AS $$
    BEGIN
        INSERT INTO "Customer"("FirstName", "LastName", "Email", "PhoneNumber") VALUES ("_firstName", "_lastName",
             "_email", "_phoneNumber");
        RETURN 'Added';
    END
    $$;

--                         P  R  O  P  E  R  T  Y

create OR REPLACE function "GetAllProperty"()
    returns TABLE("PropertyId" bigint, "PropertyUuid" UUID, "PropertyName" CHARACTER VARYING, "PropertyTypeId" INTEGER,
      "LocationId" INTEGER, "Space" INTEGER, "Rooms" INTEGER, "Cost" double precision,"CreatedAt" timestamp)
    language plpgsql
as
$$
BEGIN
   RETURN QUERY
   SELECT P."PropertyId", P."PropertyUuid", P."PropertytName", P."PropertyTypeId", P."LocationId", P."Space", P."Rooms",
          P."Cost", P."CreatedAt"
      FROM "Property" P
      WHERE "Active" = TRUE;
   END
$$;

CREATE FUNCTION "DeleteProperty"("_propertyUuid" UUID)
RETURNS CHARACTER VARYING
LANGUAGE plpgsql
AS $$
    BEGIN
        update "Property"
        SET "Active" = FALSE
        WHERE "PropertyUuid" = "_propertyUuid";

        RETURN  'Deleted';


    end

    $$;

create function "InsertProperty"("_propertyName" character varying, "_propertyTypeId" integer, "_locationId" integer, _space integer, _rooms integer, _cost double precision, "_createdAt" timestamp without time zone) returns bigint
    language plpgsql
as
$$
    DECLARE newPropertyId bigint;
BEGIN

        INSERT INTO "Property"("PropertytName", "PropertyTypeId", "LocationId", "Space", "Rooms", "Cost","CreatedAt")
         VALUES ("_propertyName", "_propertyTypeId",
             "_locationId", "_space", "_rooms", "_cost", "_createdAt")
             RETURNING "PropertyId" INTO newPropertyId;
        RETURN newPropertyId;
    END
$$;









