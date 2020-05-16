
CREATE SEQUENCE user_id;


CREATE TABLE "User" (
  "Id" int8 NOT NULL default NEXTVAL('user_id') PRIMARY KEY,
  "Name" text,
  "CreatedDateTime" timestamp
);

CREATE TABLE "UserSecurity" (
  "UserId" int8,
  "Login" text,
  "Password" text,
  "Email" text 
);

CREATE TABLE "Map" (
  "Id" int8 PRIMARY KEY,
  "Name" text,
  "Height" int8,
  "Width" int8,
  "PicUrl" text
);

CREATE TABLE "Decoration" (
  "Id" int8 PRIMARY KEY,
  "Name" text,
  "Height" int8,
  "Width" int8,
  "PicUrl" text
);

CREATE TABLE "MapDecoration" (
  "DecorationId" int8,
  "MapId" int8,
  "PositionX" int8,
  "PositionY" int8,
  CONSTRAINT "MapDecoration_pkey" PRIMARY KEY ("DecorationId", "MapId")
);

ALTER TABLE "UserSecurity" ADD FOREIGN KEY ("UserId") REFERENCES "User" ("Id");

ALTER TABLE "MapDecoration" ADD FOREIGN KEY ("MapId") REFERENCES "Map" ("Id");

ALTER TABLE "MapDecoration" ADD FOREIGN KEY ("DecorationId") REFERENCES "Decoration" ("Id");
