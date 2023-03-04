ALTER TABLE "public"."sda_project_person" DROP CONSTRAINT "FK_sda_project_person_project_id";
ALTER TABLE "public"."sda_project_person" DROP CONSTRAINT "FK_sda_person_project_person_id";
DROP TABLE IF EXISTS "public"."sda_project";
DROP TABLE IF EXISTS "public"."sda_project_person";
DROP TABLE IF EXISTS "public"."sda_person";
CREATE TABLE "public"."sda_project" ( 
  "id" SERIAL,
  "project_name" VARCHAR(50) NOT NULL,
  CONSTRAINT "sda_project_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."sda_project_person" ( 
  "id" SERIAL,
  "project_id" INTEGER NOT NULL,
  "person_id" INTEGER NOT NULL,
  "hours" INTEGER NOT NULL,
  CONSTRAINT "sda_project_person_pkey" PRIMARY KEY ("id")
);
CREATE TABLE "public"."sda_person" ( 
  "id" SERIAL,
  "person_name" VARCHAR(25) NOT NULL,
  CONSTRAINT "sda_person_pkey" PRIMARY KEY ("id")
);
INSERT INTO "public"."sda_project" ("project_name") VALUES ('Webshop');
INSERT INTO "public"."sda_project" ("project_name") VALUES ('Bank Application');
INSERT INTO "public"."sda_project_person" ("project_id", "person_id", "hours") VALUES (4, 2, 5);
INSERT INTO "public"."sda_project_person" ("project_id", "person_id", "hours") VALUES (4, 2, 4);
INSERT INTO "public"."sda_project_person" ("project_id", "person_id", "hours") VALUES (5, 2, 8);
INSERT INTO "public"."sda_person" ("person_name") VALUES ('Steven');
INSERT INTO "public"."sda_person" ("person_name") VALUES ('Erik');
INSERT INTO "public"."sda_person" ("person_name") VALUES ('Anders');
ALTER TABLE "public"."sda_project_person" ADD CONSTRAINT "FK_sda_project_person_project_id" FOREIGN KEY ("project_id") REFERENCES "public"."sda_project" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;
ALTER TABLE "public"."sda_project_person" ADD CONSTRAINT "FK_sda_person_project_person_id" FOREIGN KEY ("person_id") REFERENCES "public"."sda_person" ("id") ON DELETE NO ACTION ON UPDATE NO ACTION;