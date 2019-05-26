DROP USER IF EXISTS "vacanza";

CREATE USER "vacanza" WITH
    LOGIN
    SUPERUSER
    INHERIT
    CREATEDB
    CREATEROLE
    ENCRYPTED PASSWORD 'vacanza'
    NOREPLICATION;

CREATE DATABASE "vacanza"
    WITH
    OWNER = "vacanza"
    ENCODING = 'UTF8'
    LC_COLLATE = 'C'
    LC_CTYPE = 'UTF-8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;