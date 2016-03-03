--
-- ER/Studio 8.0 SQL Code Generation
-- Company :      Dylan
-- Project :      Centro Educacional v2.5.DM1
-- Author :       Dylan
--
-- Date Created : Sunday, February 21, 2016 11:38:37
-- Target DBMS : MySQL 5.x
--

-- 
-- TABLE: ASIGNACION_PARQUEO 
--

CREATE TABLE ASIGNACION_PARQUEO(
    codigo_asignacion_parqueo    INT    auto_increment NOT NULL,
    codigo_parqueo               INT    NOT NULL,
    codigoCarnet                 INT    NOT NULL,
    PRIMARY KEY (codigo_asignacion_parqueo)
)
;



-- 
-- TABLE: ASIGNACION_PENSUM 
--

CREATE TABLE ASIGNACION_PENSUM(
    codigo_asignacion_pensum    INT    auto_increment NOT NULL,
    codigoCarnet                INT    NOT NULL,
    codigo_creacion_pensum      INT    NOT NULL,
    PRIMARY KEY (codigo_asignacion_pensum)
)
;



-- 
-- TABLE: ASIGNACIONCURSO 
--

CREATE TABLE ASIGNACIONCURSO(
    codigoInscripcion    INT         NOT NULL,
    anio                 CHAR(10),
    ciclo                CHAR(10),
    ccodigo_paquete      INT         NOT NULL,
    PRIMARY KEY (codigoInscripcion)
)
;



-- 
-- TABLE: BITACORA 
--

CREATE TABLE BITACORA(
    accion            CHAR(20),
    tabla             CHAR(20),
    fecha             CHAR(20),
    codigo_usuario    INT         NOT NULL
)
;



-- 
-- TABLE: CARNET 
--

CREATE TABLE CARNET(
    codigoCarnet     INT         auto_increment NOT NULL,
    jornada          INT         NOT NULL,
    ano              INT         NOT NULL,
    correlativo      INT         NOT NULL,
    estado           CHAR(10),
    codigopersona    INT         NOT NULL,
    PRIMARY KEY (codigoCarnet)
)
;



-- 
-- TABLE: CARRERA 
--

CREATE TABLE CARRERA(
    codigoCarrera     INT            auto_increment NOT NULL,
    nombre            VARCHAR(50)    NOT NULL,
    estado            CHAR(25),
    codigoFacultad    INT            NOT NULL,
    codigo_sede       INT            NOT NULL,
    PRIMARY KEY (codigoCarrera)
)
;



-- 
-- TABLE: CONTRATO 
--

CREATE TABLE CONTRATO(
    codigo_contrato    INT               auto_increment NOT NULL,
    fecha_contrato     DATE              NOT NULL,
    salario            DECIMAL(10, 2)    NOT NULL,
    estado             CHAR(10),
    codigo_empleado    INT               NOT NULL,
    PRIMARY KEY (codigo_contrato)
)
;



-- 
-- TABLE: CREACION_PENSUM 
--

CREATE TABLE CREACION_PENSUM(
    codigo_creacion_pensum    INT         auto_increment NOT NULL,
    estado                    CHAR(10),
    codigo_pensum             INT         NOT NULL,
    codigo_curso              INT         NOT NULL,
    PRIMARY KEY (codigo_creacion_pensum)
)
;



-- 
-- TABLE: CURSO 
--

CREATE TABLE CURSO(
    codigo_curso    INT            auto_increment NOT NULL,
    nombre          VARCHAR(50)    NOT NULL,
    valor           CHAR(20),
    creditos        CHAR(20),
    estado          CHAR(25),
    PRIMARY KEY (codigo_curso)
)
;



-- 
-- TABLE: CURSOS_APROBADOS 
--

CREATE TABLE CURSOS_APROBADOS(
    codigo_cursos_aprobados    INT    auto_increment NOT NULL,
    codigo_encabezado_nota     INT    NOT NULL,
    PRIMARY KEY (codigo_cursos_aprobados)
)
;



-- 
-- TABLE: DIRECCION 
--

CREATE TABLE DIRECCION(
    codigo_direccion    INT         auto_increment NOT NULL,
    direccion           CHAR(30),
    estado              CHAR(10),
    codigopersona       INT         NOT NULL,
    PRIMARY KEY (codigo_direccion)
)
;



-- 
-- TABLE: EMAIL 
--

CREATE TABLE EMAIL(
    codigo_email     INT         auto_increment NOT NULL,
    email            CHAR(20),
    estado           CHAR(25),
    codigopersona    INT         NOT NULL,
    PRIMARY KEY (codigo_email)
)
;



-- 
-- TABLE: EMPLEADO 
--

CREATE TABLE EMPLEADO(
    codigo_empleado    INT         auto_increment NOT NULL,
    no_cuenta          INT,
    estado             CHAR(10),
    codigo_rol         INT         NOT NULL,
    codigopersona      INT         NOT NULL,
    PRIMARY KEY (codigo_empleado)
)
;



-- 
-- TABLE: ENCABEZADO_INCRIPCION 
--

CREATE TABLE ENCABEZADO_INCRIPCION(
    codigoInscripcion    INT     auto_increment NOT NULL,
    fecha                DATE    NOT NULL,
    codigoJornada        INT     NOT NULL,
    codigoCarrera        INT     NOT NULL,
    codigoCarnet         INT     NOT NULL,
    PRIMARY KEY (codigoInscripcion)
)
;



-- 
-- TABLE: ENCABEZADO_NOTA 
--

CREATE TABLE ENCABEZADO_NOTA(
    codigo_encabezado_nota    INT         auto_increment NOT NULL,
    calificacion              INT,
    fecha                     CHAR(20),
    estado                    CHAR(10),
    codigoCarnet              INT         NOT NULL,
    codigoInscripcion         INT         NOT NULL,
    PRIMARY KEY (codigo_encabezado_nota)
)
;



-- 
-- TABLE: ENCARGADO 
--

CREATE TABLE ENCARGADO(
    codigo_encargado    INT         auto_increment NOT NULL,
    nombre              CHAR(20),
    apellido            CHAR(20),
    direccion           CHAR(20),
    telefono            CHAR(20),
    estado              CHAR(25),
    codigoCarnet        INT         NOT NULL,
    PRIMARY KEY (codigo_encargado)
)
;



-- 
-- TABLE: EQUIVALENCIA 
--

CREATE TABLE EQUIVALENCIA(
    codigo_equivalencia       INT    auto_increment NOT NULL,
    codigo_encabezado_nota    INT    NOT NULL,
    PRIMARY KEY (codigo_equivalencia)
)
;



-- 
-- TABLE: FACULTAD 
--

CREATE TABLE FACULTAD(
    codigoFacultad    INT            auto_increment NOT NULL,
    nombre            VARCHAR(30)    NOT NULL,
    estado            CHAR(25),
    PRIMARY KEY (codigoFacultad)
)
;



-- 
-- TABLE: HORARIO 
--

CREATE TABLE HORARIO(
    codigoHorario    INT            auto_increment NOT NULL,
    rangoHora        VARCHAR(30)    NOT NULL,
    estado           CHAR(25),
    PRIMARY KEY (codigoHorario)
)
;



-- 
-- TABLE: JORNADA 
--

CREATE TABLE JORNADA(
    codigoJornada    INT            auto_increment NOT NULL,
    nombre           VARCHAR(30)    NOT NULL,
    horario          VARCHAR(15)    NOT NULL,
    estado           CHAR(25),
    PRIMARY KEY (codigoJornada)
)
;



-- 
-- TABLE: LABORATORIO 
--

CREATE TABLE LABORATORIO(
    codigo_laboratorio    INT        auto_increment NOT NULL,
    nombre                CHAR(20),
    numero                CHAR(20),
    tipo                  CHAR(20),
    estado                CHAR(25),
    PRIMARY KEY (codigo_laboratorio)
)
;



-- 
-- TABLE: NOTA 
--

CREATE TABLE NOTA(
    codigo_nota               INT    auto_increment NOT NULL,
    nota                      INT,
    codigo_encabezado_nota    INT    NOT NULL,
    codigo_empleado           INT    NOT NULL,
    codig_tipo_nota           INT    NOT NULL,
    PRIMARY KEY (codigo_nota)
)
;



-- 
-- TABLE: PAQUETE 
--

CREATE TABLE PAQUETE(
    ccodigo_paquete       INT         auto_increment NOT NULL,
    estado                CHAR(10),
    codigo_curso          INT         NOT NULL,
    codigo_salon          INT         NOT NULL,
    codigo_laboratorio    INT         NOT NULL,
    codigoHorario         INT         NOT NULL,
    codigo_seccion        INT         NOT NULL,
    codigo_empleado       INT         NOT NULL,
    PRIMARY KEY (ccodigo_paquete)
)
;



-- 
-- TABLE: PARAMETRIZACION 
--

CREATE TABLE PARAMETRIZACION(
    codigo_parametrizacion    INT         auto_increment NOT NULL,
    parametro                 CHAR(25),
    estado                    CHAR(25),
    codigo_usuario            INT         NOT NULL,
    PRIMARY KEY (codigo_parametrizacion)
)
;



-- 
-- TABLE: PARQUEO 
--

CREATE TABLE PARQUEO(
    codigo_parqueo    INT         auto_increment NOT NULL,
    numero_parqueo    INT,
    cantidad          INT,
    ubicacion         CHAR(30),
    estado            CHAR(25),
    PRIMARY KEY (codigo_parqueo)
)
;



-- 
-- TABLE: PENSUM 
--

CREATE TABLE PENSUM(
    codigo_pensum    INT         auto_increment NOT NULL,
    ano              CHAR(10),
    estado           CHAR(25),
    codigoCarrera    INT         NOT NULL,
    PRIMARY KEY (codigo_pensum)
)
;



-- 
-- TABLE: PERSONA 
--

CREATE TABLE PERSONA(
    codigopersona      INT             auto_increment NOT NULL,
    nombre             VARCHAR(20),
    apellido           VARCHAR(120),
    fechaNacimiento    DATE,
    dpi                VARCHAR(15),
    sexo               CHAR(25),
    estado             CHAR(25),
    PRIMARY KEY (codigopersona)
)
;



-- 
-- TABLE: PREREQUISITO 
--

CREATE TABLE PREREQUISITO(
    codigo_prerequisito    INT    NOT NULL,
    codigo_curso           INT    NOT NULL
)
;



-- 
-- TABLE: PRIVILEGIOS 
--

CREATE TABLE PRIVILEGIOS(
    codigo_privilegios    INT         auto_increment NOT NULL,
    formulario            CHAR(20),
    permiso               CHAR(20),
    estado                CHAR(25),
    codigo_rol            INT         NOT NULL,
    PRIMARY KEY (codigo_privilegios)
)
;



-- 
-- TABLE: PUESTO 
--

CREATE TABLE PUESTO(
    codigo_rol    INT         auto_increment NOT NULL,
    nombre        CHAR(20),
    estado        CHAR(25),
    PRIMARY KEY (codigo_rol)
)
;



-- 
-- TABLE: ROL 
--

CREATE TABLE ROL(
    codigo_rol     INT         auto_increment NOT NULL,
    tipo           CHAR(10),
    descripcion    CHAR(20),
    estado         CHAR(25),
    PRIMARY KEY (codigo_rol)
)
;



-- 
-- TABLE: SALON 
--

CREATE TABLE SALON(
    codigo_salon    INT         auto_increment NOT NULL,
    nombre_salon    CHAR(10),
    cupo            CHAR(10),
    estado          CHAR(10),
    codigo_sede     INT         NOT NULL,
    PRIMARY KEY (codigo_salon)
)
;



-- 
-- TABLE: SECCION 
--

CREATE TABLE SECCION(
    codigo_seccion    INT         auto_increment NOT NULL,
    nombre            CHAR(20),
    estado            CHAR(25),
    PRIMARY KEY (codigo_seccion)
)
;



-- 
-- TABLE: SEDES 
--

CREATE TABLE SEDES(
    codigo_sede    INT         auto_increment NOT NULL,
    nombre         CHAR(25),
    ubicacion      CHAR(25),
    estado         CHAR(25),
    PRIMARY KEY (codigo_sede)
)
;



-- 
-- TABLE: SERVICIO 
--

CREATE TABLE SERVICIO(
    codigo_servicio         INT               auto_increment NOT NULL,
    codigo_tipo_servicio    INT               NOT NULL,
    cod_tipo_pago           INT               NOT NULL,
    codigo_contrato         INT               NOT NULL,
    codigoCarnet            INT               NOT NULL,
    monto                   DECIMAL(10, 2),
    fecha                   DATE,
    estado                  CHAR(10),
    PRIMARY KEY (codigo_servicio)
)
;



-- 
-- TABLE: TELEFONO 
--

CREATE TABLE TELEFONO(
    codigo_telefono    INT         auto_increment NOT NULL,
    telefono           CHAR(20),
    estado             CHAR(25),
    codigopersona      INT         NOT NULL,
    PRIMARY KEY (codigo_telefono)
)
;



-- 
-- TABLE: TIPO_NOTA 
--

CREATE TABLE TIPO_NOTA(
    codig_tipo_nota    INT          auto_increment NOT NULL,
    descripcion        CHAR(100),
    valor              INT,
    estado             CHAR(10),
    ccodigo_paquete    INT          NOT NULL,
    PRIMARY KEY (codig_tipo_nota)
)
;



-- 
-- TABLE: TIPO_PAGO 
--

CREATE TABLE TIPO_PAGO(
    cod_tipo_pago    INT         auto_increment NOT NULL,
    descripcion      CHAR(35),
    cuotas           CHAR(10),
    estado           CHAR(25),
    PRIMARY KEY (cod_tipo_pago)
)
;



-- 
-- TABLE: TIPO_SERVICIO 
--

CREATE TABLE TIPO_SERVICIO(
    codigo_tipo_servicio    INT               auto_increment NOT NULL,
    descripcion             CHAR(50),
    fecha_corte             DATE,
    monto                   DECIMAL(10, 2),
    accion                  CHAR(20),
    estado                  CHAR(25),
    PRIMARY KEY (codigo_tipo_servicio)
)
;



-- 
-- TABLE: USUARIO 
--

CREATE TABLE USUARIO(
    codigo_usuario      INT          auto_increment NOT NULL,
    nombre_usuario      CHAR(100),
    password_usuario    CHAR(100),
    codigopersona       INT          NOT NULL,
    codigo_rol          INT          NOT NULL,
    PRIMARY KEY (codigo_usuario)
)
;



-- 
-- TABLE: ASIGNACION_PARQUEO 
--

ALTER TABLE ASIGNACION_PARQUEO ADD CONSTRAINT RefPARQUEO24 
    FOREIGN KEY (codigo_parqueo)
    REFERENCES PARQUEO(codigo_parqueo)
;

ALTER TABLE ASIGNACION_PARQUEO ADD CONSTRAINT RefCARNET25 
    FOREIGN KEY (codigoCarnet)
    REFERENCES CARNET(codigoCarnet)
;


-- 
-- TABLE: ASIGNACION_PENSUM 
--

ALTER TABLE ASIGNACION_PENSUM ADD CONSTRAINT RefCARNET48 
    FOREIGN KEY (codigoCarnet)
    REFERENCES CARNET(codigoCarnet)
;

ALTER TABLE ASIGNACION_PENSUM ADD CONSTRAINT RefCREACION_PENSUM80 
    FOREIGN KEY (codigo_creacion_pensum)
    REFERENCES CREACION_PENSUM(codigo_creacion_pensum)
;


-- 
-- TABLE: ASIGNACIONCURSO 
--

ALTER TABLE ASIGNACIONCURSO ADD CONSTRAINT RefENCABEZADO_INCRIPCION35 
    FOREIGN KEY (codigoInscripcion)
    REFERENCES ENCABEZADO_INCRIPCION(codigoInscripcion)
;

ALTER TABLE ASIGNACIONCURSO ADD CONSTRAINT RefPAQUETE84 
    FOREIGN KEY (ccodigo_paquete)
    REFERENCES PAQUETE(ccodigo_paquete)
;


-- 
-- TABLE: BITACORA 
--

ALTER TABLE BITACORA ADD CONSTRAINT RefUSUARIO81 
    FOREIGN KEY (codigo_usuario)
    REFERENCES USUARIO(codigo_usuario)
;


-- 
-- TABLE: CARNET 
--

ALTER TABLE CARNET ADD CONSTRAINT RefPERSONA1 
    FOREIGN KEY (codigopersona)
    REFERENCES PERSONA(codigopersona)
;


-- 
-- TABLE: CARRERA 
--

ALTER TABLE CARRERA ADD CONSTRAINT RefFACULTAD13 
    FOREIGN KEY (codigoFacultad)
    REFERENCES FACULTAD(codigoFacultad)
;

ALTER TABLE CARRERA ADD CONSTRAINT RefSEDES74 
    FOREIGN KEY (codigo_sede)
    REFERENCES SEDES(codigo_sede)
;


-- 
-- TABLE: CONTRATO 
--

ALTER TABLE CONTRATO ADD CONSTRAINT RefEMPLEADO18 
    FOREIGN KEY (codigo_empleado)
    REFERENCES EMPLEADO(codigo_empleado)
;


-- 
-- TABLE: CREACION_PENSUM 
--

ALTER TABLE CREACION_PENSUM ADD CONSTRAINT RefPENSUM76 
    FOREIGN KEY (codigo_pensum)
    REFERENCES PENSUM(codigo_pensum)
;

ALTER TABLE CREACION_PENSUM ADD CONSTRAINT RefCURSO77 
    FOREIGN KEY (codigo_curso)
    REFERENCES CURSO(codigo_curso)
;


-- 
-- TABLE: CURSOS_APROBADOS 
--

ALTER TABLE CURSOS_APROBADOS ADD CONSTRAINT RefENCABEZADO_NOTA49 
    FOREIGN KEY (codigo_encabezado_nota)
    REFERENCES ENCABEZADO_NOTA(codigo_encabezado_nota)
;


-- 
-- TABLE: DIRECCION 
--

ALTER TABLE DIRECCION ADD CONSTRAINT RefPERSONA30 
    FOREIGN KEY (codigopersona)
    REFERENCES PERSONA(codigopersona)
;


-- 
-- TABLE: EMAIL 
--

ALTER TABLE EMAIL ADD CONSTRAINT RefPERSONA32 
    FOREIGN KEY (codigopersona)
    REFERENCES PERSONA(codigopersona)
;


-- 
-- TABLE: EMPLEADO 
--

ALTER TABLE EMPLEADO ADD CONSTRAINT RefPUESTO12 
    FOREIGN KEY (codigo_rol)
    REFERENCES PUESTO(codigo_rol)
;

ALTER TABLE EMPLEADO ADD CONSTRAINT RefPERSONA51 
    FOREIGN KEY (codigopersona)
    REFERENCES PERSONA(codigopersona)
;


-- 
-- TABLE: ENCABEZADO_INCRIPCION 
--

ALTER TABLE ENCABEZADO_INCRIPCION ADD CONSTRAINT RefJORNADA3 
    FOREIGN KEY (codigoJornada)
    REFERENCES JORNADA(codigoJornada)
;

ALTER TABLE ENCABEZADO_INCRIPCION ADD CONSTRAINT RefCARRERA5 
    FOREIGN KEY (codigoCarrera)
    REFERENCES CARRERA(codigoCarrera)
;

ALTER TABLE ENCABEZADO_INCRIPCION ADD CONSTRAINT RefCARNET16 
    FOREIGN KEY (codigoCarnet)
    REFERENCES CARNET(codigoCarnet)
;


-- 
-- TABLE: ENCABEZADO_NOTA 
--

ALTER TABLE ENCABEZADO_NOTA ADD CONSTRAINT RefCARNET40 
    FOREIGN KEY (codigoCarnet)
    REFERENCES CARNET(codigoCarnet)
;

ALTER TABLE ENCABEZADO_NOTA ADD CONSTRAINT RefASIGNACIONCURSO41 
    FOREIGN KEY (codigoInscripcion)
    REFERENCES ASIGNACIONCURSO(codigoInscripcion)
;


-- 
-- TABLE: ENCARGADO 
--

ALTER TABLE ENCARGADO ADD CONSTRAINT RefCARNET52 
    FOREIGN KEY (codigoCarnet)
    REFERENCES CARNET(codigoCarnet)
;


-- 
-- TABLE: EQUIVALENCIA 
--

ALTER TABLE EQUIVALENCIA ADD CONSTRAINT RefENCABEZADO_NOTA50 
    FOREIGN KEY (codigo_encabezado_nota)
    REFERENCES ENCABEZADO_NOTA(codigo_encabezado_nota)
;


-- 
-- TABLE: NOTA 
--

ALTER TABLE NOTA ADD CONSTRAINT RefENCABEZADO_NOTA44 
    FOREIGN KEY (codigo_encabezado_nota)
    REFERENCES ENCABEZADO_NOTA(codigo_encabezado_nota)
;

ALTER TABLE NOTA ADD CONSTRAINT RefEMPLEADO58 
    FOREIGN KEY (codigo_empleado)
    REFERENCES EMPLEADO(codigo_empleado)
;

ALTER TABLE NOTA ADD CONSTRAINT RefTIPO_NOTA73 
    FOREIGN KEY (codig_tipo_nota)
    REFERENCES TIPO_NOTA(codig_tipo_nota)
;


-- 
-- TABLE: PAQUETE 
--

ALTER TABLE PAQUETE ADD CONSTRAINT RefCURSO65 
    FOREIGN KEY (codigo_curso)
    REFERENCES CURSO(codigo_curso)
;

ALTER TABLE PAQUETE ADD CONSTRAINT RefSALON66 
    FOREIGN KEY (codigo_salon)
    REFERENCES SALON(codigo_salon)
;

ALTER TABLE PAQUETE ADD CONSTRAINT RefLABORATORIO67 
    FOREIGN KEY (codigo_laboratorio)
    REFERENCES LABORATORIO(codigo_laboratorio)
;

ALTER TABLE PAQUETE ADD CONSTRAINT RefHORARIO68 
    FOREIGN KEY (codigoHorario)
    REFERENCES HORARIO(codigoHorario)
;

ALTER TABLE PAQUETE ADD CONSTRAINT RefSECCION69 
    FOREIGN KEY (codigo_seccion)
    REFERENCES SECCION(codigo_seccion)
;

ALTER TABLE PAQUETE ADD CONSTRAINT RefEMPLEADO70 
    FOREIGN KEY (codigo_empleado)
    REFERENCES EMPLEADO(codigo_empleado)
;


-- 
-- TABLE: PARAMETRIZACION 
--

ALTER TABLE PARAMETRIZACION ADD CONSTRAINT RefUSUARIO86 
    FOREIGN KEY (codigo_usuario)
    REFERENCES USUARIO(codigo_usuario)
;


-- 
-- TABLE: PENSUM 
--

ALTER TABLE PENSUM ADD CONSTRAINT RefCARRERA26 
    FOREIGN KEY (codigoCarrera)
    REFERENCES CARRERA(codigoCarrera)
;


-- 
-- TABLE: PREREQUISITO 
--

ALTER TABLE PREREQUISITO ADD CONSTRAINT RefCURSO85 
    FOREIGN KEY (codigo_curso)
    REFERENCES CURSO(codigo_curso)
;


-- 
-- TABLE: PRIVILEGIOS 
--

ALTER TABLE PRIVILEGIOS ADD CONSTRAINT RefROL56 
    FOREIGN KEY (codigo_rol)
    REFERENCES ROL(codigo_rol)
;


-- 
-- TABLE: SALON 
--

ALTER TABLE SALON ADD CONSTRAINT RefSEDES75 
    FOREIGN KEY (codigo_sede)
    REFERENCES SEDES(codigo_sede)
;


-- 
-- TABLE: SERVICIO 
--

ALTER TABLE SERVICIO ADD CONSTRAINT RefTIPO_SERVICIO59 
    FOREIGN KEY (codigo_tipo_servicio)
    REFERENCES TIPO_SERVICIO(codigo_tipo_servicio)
;

ALTER TABLE SERVICIO ADD CONSTRAINT RefTIPO_PAGO60 
    FOREIGN KEY (cod_tipo_pago)
    REFERENCES TIPO_PAGO(cod_tipo_pago)
;

ALTER TABLE SERVICIO ADD CONSTRAINT RefCONTRATO61 
    FOREIGN KEY (codigo_contrato)
    REFERENCES CONTRATO(codigo_contrato)
;

ALTER TABLE SERVICIO ADD CONSTRAINT RefCARNET63 
    FOREIGN KEY (codigoCarnet)
    REFERENCES CARNET(codigoCarnet)
;


-- 
-- TABLE: TELEFONO 
--

ALTER TABLE TELEFONO ADD CONSTRAINT RefPERSONA31 
    FOREIGN KEY (codigopersona)
    REFERENCES PERSONA(codigopersona)
;


-- 
-- TABLE: TIPO_NOTA 
--

ALTER TABLE TIPO_NOTA ADD CONSTRAINT RefPAQUETE72 
    FOREIGN KEY (ccodigo_paquete)
    REFERENCES PAQUETE(ccodigo_paquete)
;


-- 
-- TABLE: USUARIO 
--

ALTER TABLE USUARIO ADD CONSTRAINT RefPERSONA53 
    FOREIGN KEY (codigopersona)
    REFERENCES PERSONA(codigopersona)
;

ALTER TABLE USUARIO ADD CONSTRAINT RefROL54 
    FOREIGN KEY (codigo_rol)
    REFERENCES ROL(codigo_rol)
;


