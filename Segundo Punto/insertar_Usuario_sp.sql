CREATE OR REPLACE PROCEDURE public.insertar_usuario(
    _nombre VARCHAR(255),
    _telefono VARCHAR(20),
    _direccion VARCHAR(255),
    _id_pais INT,
    _id_departamento INT,
    _id_municipio INT)
LANGUAGE plpgsql
AS $$
BEGIN
    INSERT INTO usuarios (nombre, telefono, direccion, id_pais, id_departamento, id_municipio)
    VALUES (_nombre, _telefono, _direccion, _id_pais, _id_departamento, _id_municipio);
END; $$
