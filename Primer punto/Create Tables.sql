CREATE TABLE pais (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

CREATE TABLE departamento (
    id SERIAL PRIMARY KEY,
    id_pais INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    FOREIGN KEY (id_pais) REFERENCES pais(id)
);

CREATE TABLE municipio (
    id SERIAL PRIMARY KEY,
    id_departamento INT NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    FOREIGN KEY (id_departamento) REFERENCES departamento(id)
);

CREATE TABLE usuarios (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    telefono VARCHAR(20),
    direccion VARCHAR(255),
    id_pais INT,
    id_departamento INT,
    id_municipio INT,
    FOREIGN KEY (id_pais) REFERENCES pais(id),
    FOREIGN KEY (id_departamento) REFERENCES departamento(id),
    FOREIGN KEY (id_municipio) REFERENCES municipio(id)
);
