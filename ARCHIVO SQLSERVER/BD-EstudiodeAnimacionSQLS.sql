USE master;
GO
IF DB_ID (N'EstudiodeAnimacion') IS NOT NULL
DROP DATABASE EstudiodeAnimacion;
CREATE DATABASE EstudiodeAnimacion
ON
(NAME  = EstudiodeAnimacion_dat,
       FILENAME = 'C:\samples\EstudiodeAnimacion.mdf',
	   SIZE =10,
	   MAXSIZE = 50,
	   FILEGROWTH = 5)
LOG ON
(NAME = EstudiodeAnimacion_log,
	  FILENAME = 'C:\samples\EstudiodeAnimacion.ldf',
      SIZE = 5MB,
      MAXSIZE = 25MB,
      FILEGROWTH = 5MB ) ;
GO 
USE EstudiodeAnimacion;
GO
CREATE TABLE Animatic2D
(
idAnimatic2D INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
personaje VARCHAR (50) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE ArteConceptual
(
 idArteConceptual INT IDENTITY (1,1),
 concepto VARCHAR (50),
 fechaEntrega DATETIME NOT NULL,
 estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Cambio
(
idCambio INT IDENTITY (1,1),
cambio VARCHAR (50) NOT NULL,
descripcion VARCHAR (100) NOT NULL,
fecha DATETIME NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Director
(
idDirector INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
apellidoPaterno VARCHAR (50) NOT NULL,
apellidoMaterno VARCHAR (50) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Ingreso
(
idIngreso INT IDENTITY (1,1),
ingreso INT NOT NULL,
descripcion VARCHAR (50) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE JuntaDirectiva
(
idJuntaDirectiva INT IDENTITY (1,1),
motivo VARCHAR (50) NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Layout
(
idLayout INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
correccionDibujo VARCHAR (50) NOT NULL,
tipo VARCHAR (30),
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Musico
(
idMusico INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
apellidoPaterno VARCHAR (50) NOT NULL,
apellidoMaterno VARCHAR (50) NOT NULL,
tipoMusica VARCHAR (30) NOT NULL, 
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE PostProduccion
(
idPostProduccion INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
correccionFinal VARCHAR (100) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE StoryBoard
(
idStoryBoard INT IDENTITY (1,1),
tituloEscena VARCHAR (30) NOT NULL,
ideaEscena VARCHAR (50) NOT NULL,
fechaEntrega DATETIME NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE VFX
(idVFX INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
tipo VARCHAR (50) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Actor
(
idActor INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
apellidoPaterno VARCHAR (50) NOT NULL,
apellidoMaterno VARCHAR (50) NOT NULL,
personaje VARCHAR (30) NOT NULL, 
idDirector INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE AsistenteAnimacion
(
idAsistenteAnimacion INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
apellidoPaterno VARCHAR (50) NOT NULL,
apellidoMaterno VARCHAR (50) NOT NULL,
idDirector INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Animacion
(
idAnimacion INT IDENTITY (1,1),
nombre VARCHAR (30) NOT NULL,
fechaEntrega DATETIME NOT NULL,
idAsistenteAnimacion INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Animador
(
idAnimador INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
apellidoPaterno VARCHAR (50) NOT NULL,
apellidoMaterno VARCHAR (50) NOT NULL,
especializacion VARCHAR (50) NOT NULL,
idDirector INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Artista
(
idArtista INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
apellidoPaterno VARCHAR (50) NOT NULL,
apellidoMaterno VARCHAR (50) NOT NULL,
especializacion VARCHAR (50) NOT NULL,
idDirector INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Colaboracion
(
idColaboracion INT IDENTITY (1,1),
estudio VARCHAR (50) NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
idJuntaDirectiva INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE ColorScript
(
idColorScript INT IDENTITY (1,1),
descripcion VARCHAR (50) NOT NULL,
fechaEntrega DATETIME NOT NULL,
idArtista INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO 
CREATE TABLE Tecnico
(
idTecnico INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
apellidoPaterno VARCHAR (50) NOT NULL,
apellidoMaterno VARCHAR (50) NOT NULL,
especializacion VARCHAR (50) NOT NULL,
idDirector INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Compositing
(
idCompositing INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
idTecnico INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE CorreccionColor
(
idCorreccionColor INT IDENTITY (1,1),
descripcion VARCHAR (50) NOT NULL,
fechaEntrega DATETIME NOT NULL,
idTecnico INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE DiaPresentacion
(
idDiaPresentacion INT IDENTITY (1,1),
descripcion VARCHAR (50) NOT NULL,
fecha DATETIME NOT NULL,
idJuntaDirectiva INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE  Directivo
(
idDirectivo INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
apellidoPaterno VARCHAR (50) NOT NULL,
apellidoMaterno VARCHAR (50) NOT NULL,
departamento VARCHAR (50) NOT NULL,
idJuntaDirectiva INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Esqueletizacion
(
idEsqueletizacion INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
idTecnico INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Gerente 
(
idGerente INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
apellidoPaterno VARCHAR (50) NOT NULL,
apellidoMaterno VARCHAR (50) NOT NULL,
departamento VARCHAR (50) NOT NULL,
idDirectivo INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE ExhibicionInternacional
(
idExhibicionInternacional INT IDENTITY (1,1),
feha DATETIME NOT NULL,
calle VARCHAR (50) NOT NULL,
numero CHAR (100) NOT NULL,
colonia VARCHAR (50) NOT NULL,
ciudad VARCHAR (50) NOT NULL,
pais VARCHAR (50) NOT NULL,
idGerente INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO 
CREATE TABLE ExhibicionNacional
(
idExhibicionNacional INT IDENTITY (1,1),
feha DATETIME NOT NULL,
calle VARCHAR (50) NOT NULL,
numero CHAR (100) NOT NULL,
colonia VARCHAR (50) NOT NULL,
ciudad VARCHAR (50) NOT NULL,
codigoPostal CHAR (6) NOT NULL,
idGerente INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO 
CREATE TABLE Fondista
(
idFondista INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
apellidoPaterno VARCHAR (50) NOT NULL,
apellidoMaterno VARCHAR (50) NOT NULL,
idDirector INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO 
CREATE TABLE FxPersonaje
(
idFxPersonaje INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
idTecnico INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE GrabacionVoz
(
idGrabacionVoz INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
idTecnico INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Guionista
(
idGuionista INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
apellidoPaterno VARCHAR (50) NOT NULL,
apellidoMaterno VARCHAR (50) NOT NULL,
idGerente INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Guion
(
idGuion INT IDENTITY (1,1),
titulo VARCHAR (30) NOT NULL,
fechaEntrega DATETIME NOT NULL,
idGuionista INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Idea
(
idIdea INT IDENTITY (1,1),
propuesta VARCHAR (100) NOT NULL,
fechaEntrega DATETIME NOT NULL,
idJuntaDirectiva INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Iluminacion
(
idIluminacion INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
descripcion VARCHAR (50),
idTecnico INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Masterizacion
(
idMasterizacion INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
tipoAudio VARCHAR (30),
idTecnico INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE MattePainting
(
idMattePainting INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
idFondista INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Modelado
(
idModelado INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
idAsistenteAnimacion INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Musica
(
idMusica INT IDENTITY (1,1),
nombre VARCHAR (30)NOT NULL,
genero VARCHAR (30)NOT NULL,
fechaEntrega DATETIME NOT NULL,
idTecnico INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Patrocinador
(
idPatrocinador INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
apellidoPaterno VARCHAR (50) NOT NULL,
apellidoMaterno VARCHAR (50) NOT NULL,
empresa VARCHAR (30) NOT NULL,
idJuntaDirectiva INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Pelicula
(
idPelicula INT IDENTITY (1,1),
titulo VARCHAR (30) NOT NULL,
genero VARCHAR (30) NOT NULL,
clasificacion VARCHAR (6) NOT NULL,
duracion CHAR (150) NOT NULL,
idJuntaDirectiva INT NOT NULL,
idDirector INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE PreExhibicion
(
idPreExhibicion INT IDENTITY (1,1),
feha DATETIME NOT NULL,
calle VARCHAR (50) NOT NULL,
numero CHAR (100) NOT NULL,
colonia VARCHAR (50) NOT NULL,
ciudad VARCHAR (50) NOT NULL,
codigoPostal CHAR (6) NOT NULL,
numParticipantes CHAR (100) NOT NULL,
idGerente INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Presupuesto
(
idPresupuesto INT IDENTITY (1,1),
desarrolloInv INT NOT NULL,
areaTecnica INT NOT NULL, 
areaArtistica INT NOT NULL,
marketing INT NOT NULL,
idGerente INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Productor
(
idProductor INT IDENTITY (1,1),
nombre VARCHAR (50) NOT NULL,
apellidoPaterno VARCHAR (50) NOT NULL,
apellidoMaterno VARCHAR (50) NOT NULL,
idGerente INT NOT NULL,
idDirector INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Publicidad
(
idPublicidad INT IDENTITY (1,1),
medioTransimicion VARCHAR (30),
precio INT NOT NULL,
idGerente INT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE PulidoCamara
(
idPulidoCamara INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
detalles VARCHAR (100),
idTecnico INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Rediseño
(
idRediseño INT IDENTITY (1,1),
primerRediseño DATETIME NOT NULL,
segundoRediseño DATETIME NOT NULL,
idDirector INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Revision
(
idRevision INT IDENTITY (1,1),
primeraRevision DATETIME NOT NULL,
segundaRevision DATETIME NOT NULL,
idDirector INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE SetDressing
(
idSetDressing INT IDENTITY (1,1),
fechaEntrega DATETIME NOT NULL,
idFondista INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE SFX
(
idSFX INT IDENTITY (1,1),
tipo VARCHAR (50) NOT NULL,
fechaEntrega DATETIME NOT NULL,
idTecnico INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE Texturizado
(
idTexturizado INT IDENTITY (1,1),
tipo  VARCHAR (50) NOT NULL,
fechaEntrega DATETIME NOT NULL,
idTecnico INT NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE ActorGrabacionVoz
(
idActorGrabacionVoz INT IDENTITY (1,1),
idActor INT NOT NULL,
idGrabacionVoz INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE AnimacionAnimador
(
idAnimacionAnimador INT IDENTITY (1,1),
idAnimacion INT NOT NULL,
idAnimador INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE AnimadorAnimatic2D
(
idAnimadorAnimatic2D INT IDENTITY (1,1),
idAnimador INT NOT NULL,
idAnimatic2D INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE AnimadorModelo
(
idAnimadorModelo INT IDENTITY (1,1),
idAnimador INT NOT NULL,
idModelado INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE ArtistaAreaConceptual
(
idArtistaAreaConceptual INT IDENTITY (1,1),
idArtista INT NOT NULL,
idArteConceptual INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE ArtistaStoryBoard
(
idArtistaStoryBoard INT IDENTITY (1,1),
idArtista INT NOT NULL,
idStoryBoard INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE CambioDirectivo
(
idCambioDirectivo INT IDENTITY (1,1),
idCambio INT NOT NULL,
idDirectivo INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE DirectorGerente
(
idDirectorGerente INT IDENTITY (1,1),
idDirector INT NOT NULL,
idGerente INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE IngresoExhibicionInternacional
(
idIngresoExhibicionInternacional INT IDENTITY (1,1),
idIngreso INT NOT NULL,
idExhibicionInternacional INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO 
CREATE TABLE IngresoExhibicionNacional
(
idIngresoExhibicionNacional INT IDENTITY (1,1),
idIngreso INT NOT NULL,
idExhibicionNacional INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE  LayoutTecnico
(
idLayoutTecnico INT IDENTITY (1,1),
idLayout INT NOT NULL,
idTecnico INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE MusicaMusico
(
idMusicaMusico INT IDENTITY (1,1),
idMusica INT NOT NULL,
idMusico INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE PostProduccionTecnico
(
idPostProduccionTecnico INT IDENTITY (1,1),
idPostProduccion INT NOT NULL,
idTecnico INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO
CREATE TABLE VFXTecnico
(
idVFXTecnico INT IDENTITY (1,1),
idVFX INT NOT NULL,
idTecnico INT NOT NULL,
numIntegrantes CHAR (30) NOT NULL,
estatus BIT DEFAULT 1 NOT NULL
)
GO

--LLAVES PRIMARIAS
ALTER TABLE Animatic2D ADD CONSTRAINT PK_Animatic2D PRIMARY KEY (idAnimatic2D)
ALTER TABLE ArteConceptual ADD CONSTRAINT PK_ArteConceptual PRIMARY KEY (idArteConceptual)
ALTER TABLE Cambio ADD CONSTRAINT PK_Cambio PRIMARY KEY (idCambio)
ALTER TABLE Director ADD CONSTRAINT PK_Director PRIMARY KEY (idDirector)
ALTER TABLE Ingreso ADD CONSTRAINT PK_Ingreso PRIMARY KEY (idIngreso)
ALTER TABLE JuntaDirectiva ADD CONSTRAINT PK_JuntaDirectiva PRIMARY KEY (idJuntaDirectiva)
ALTER TABLE Layout ADD CONSTRAINT PK_Layout PRIMARY KEY (idLayout)
ALTER TABLE Musico ADD CONSTRAINT PK_Musico PRIMARY KEY (idMusico)
ALTER TABLE PostProduccion ADD CONSTRAINT PK_PostProduccion PRIMARY KEY (idPostProduccion)
ALTER TABLE StoryBoard ADD CONSTRAINT PK_StoryBoard PRIMARY KEY (idStoryBoard)
ALTER TABLE VFX ADD CONSTRAINT PK_VFX PRIMARY KEY (idVFX)
ALTER TABLE Actor ADD CONSTRAINT PK_Actor PRIMARY KEY (idActor)
ALTER TABLE AsistenteAnimacion ADD CONSTRAINT PK_AsistenteAnimacion PRIMARY KEY (idAsistenteAnimacion)
ALTER TABLE Animacion ADD CONSTRAINT PK_Animacion PRIMARY KEY (idAnimacion)
ALTER TABLE Animador ADD CONSTRAINT PK_Animador PRIMARY KEY (idAnimador)
ALTER TABLE Artista ADD CONSTRAINT PK_Artista PRIMARY KEY (idArtista)
ALTER TABLE Colaboracion ADD CONSTRAINT PK_Colaboracion PRIMARY KEY (idColaboracion)
ALTER TABLE ColorScript ADD CONSTRAINT PK_ColorScript PRIMARY KEY (idColorScript)
ALTER TABLE Tecnico ADD CONSTRAINT PK_Tecnico PRIMARY KEY (idTecnico)
ALTER TABLE Compositing ADD CONSTRAINT PK_Compositig PRIMARY KEY (idCompositing)
ALTER TABLE CorreccionColor ADD CONSTRAINT PK_CorreccionColor PRIMARY KEY (idCorreccionColor)
ALTER TABLE DiaPresentacion ADD CONSTRAINT PK_DiaPresentacion PRIMARY KEY (idDiaPresentacion)
ALTER TABLE Directivo ADD CONSTRAINT PK_Directivo PRIMARY KEY (idDirectivo)
ALTER TABLE Esqueletizacion ADD CONSTRAINT PK_Esqueletizacion PRIMARY KEY (idEsqueletizacion)
ALTER TABLE Gerente ADD CONSTRAINT PK_Gerente PRIMARY KEY (idGerente)
ALTER TABLE ExhibicionInternacional ADD CONSTRAINT PK_ExhibicionInternacional PRIMARY KEY (idExhibicionInternacional)
ALTER TABLE ExhibicionNacional ADD CONSTRAINT PK_ExhibicionNacional PRIMARY KEY (idExhibicionNacional)
ALTER TABLE Fondista ADD CONSTRAINT PK_Fondista PRIMARY KEY (idFondista)
ALTER TABLE FxPersonaje ADD CONSTRAINT PK_FxPersonaje PRIMARY KEY (idFxPersonaje)
ALTER TABLE GrabacionVoz ADD CONSTRAINT PK_GrabacionVoz PRIMARY KEY (idGrabacionVoz)
ALTER TABLE Guionista ADD CONSTRAINT PK_Guionista PRIMARY KEY (idGuionista)
ALTER TABLE Guion ADD CONSTRAINT PK_Guion PRIMARY KEY (idGuion)
ALTER TABLE Idea ADD CONSTRAINT PK_Idea PRIMARY KEY (idIdea)
ALTER TABLE Iluminacion ADD CONSTRAINT PK_Iluminacion PRIMARY KEY (idIluminacion)
ALTER TABLE Masterizacion ADD CONSTRAINT PK_Masterizacion PRIMARY KEY (idMasterizacion)
ALTER TABLE MattePainting ADD CONSTRAINT PK_MattePainting PRIMARY KEY (idMattePainting)
ALTER TABLE Modelado ADD CONSTRAINT PK_Modelado PRIMARY KEY (idModelado)
ALTER TABLE Musica ADD CONSTRAINT PK_Musica PRIMARY KEY (idMusica)
ALTER TABLE Patrocinador ADD CONSTRAINT PK_Patrocinador PRIMARY KEY (idPatrocinador)
ALTER TABLE Pelicula ADD CONSTRAINT PK_Pelicula PRIMARY KEY (idPelicula)
ALTER TABLE PreExhibicion ADD CONSTRAINT PK_PreExhibicion PRIMARY KEY (idPreExhibicion)
ALTER TABLE Presupuesto ADD CONSTRAINT PK_Presupuesto PRIMARY KEY (idPresupuesto)
ALTER TABLE Productor ADD CONSTRAINT PK_Productor PRIMARY KEY (idProductor)
ALTER TABLE Publicidad ADD CONSTRAINT PK_Publicidad PRIMARY KEY (idPublicidad)
ALTER TABLE PulidoCamara ADD CONSTRAINT PK_PulidoCamara PRIMARY KEY (idPulidoCamara)
ALTER TABLE Rediseño ADD CONSTRAINT PK_Rediseño PRIMARY KEY (idRediseño)
ALTER TABLE Revision ADD CONSTRAINT PK_Revision PRIMARY KEY (idRevision)
ALTER TABLE SetDressing ADD CONSTRAINT PK_SetDressing PRIMARY KEY (idSetDressing)
ALTER TABLE SFX ADD CONSTRAINT PK_SFX PRIMARY KEY (idSFX)
ALTER TABLE Texturizado ADD CONSTRAINT PK_Texturizado PRIMARY KEY (idTexturizado)
ALTER TABLE ActorGrabacionVoz ADD CONSTRAINT PK_ActorGrabacionVoz PRIMARY KEY (idActorGrabacionVoz)
ALTER TABLE AnimacionAnimador ADD CONSTRAINT PK_AnimacionAnimador PRIMARY KEY (idAnimacionAnimador)
ALTER TABLE AnimadorAnimatic2D ADD CONSTRAINT PK_AnimadorAnimatic2D PRIMARY KEY (idAnimadorAnimatic2D)
ALTER TABLE AnimadorModelo ADD CONSTRAINT PK_AnimadorModelo PRIMARY KEY (idAnimadorModelo)
ALTER TABLE ArtistaAreaConceptual ADD CONSTRAINT PK_ArtistaAreaConceptual PRIMARY KEY (idArtistaAreaConceptual)
ALTER TABLE ArtistaStoryBoard ADD CONSTRAINT PK_ArtistaStoryBoard PRIMARY KEY (idArtistaStoryBoard)
ALTER TABLE CambioDirectivo ADD CONSTRAINT PK_CambioDirectivo PRIMARY KEY (idCambioDirectivo)
ALTER TABLE DirectorGerente ADD CONSTRAINT PK_DirectorGerente PRIMARY KEY (idDirectorGerente)
ALTER TABLE IngresoExhibicionInternacional ADD CONSTRAINT PK_IngresoExhibicionInternacional PRIMARY KEY (idIngresoExhibicionInternacional)
ALTER TABLE IngresoExhibicionNacional ADD CONSTRAINT PK_IngresoExhibicioNacional PRIMARY KEY (idIngresoExhibicionNacional)
ALTER TABLE LayoutTecnico ADD CONSTRAINT PK_LayoutTecnico PRIMARY KEY (idLayoutTecnico)
ALTER TABLE MusicaMusico ADD CONSTRAINT PK_MusicaMusico PRIMARY KEY (idMusicaMusico)
ALTER TABLE PostProduccionTecnico ADD CONSTRAINT PK_PostProduccionTecnico PRIMARY KEY (idPostProduccionTecnico)
ALTER TABLE VFXTecnico ADD CONSTRAINT PK_VFXTecnico PRIMARY KEY (idVFXTecnico)

--LLAVES FOREANEAS
--ACTOR
ALTER TABLE Actor ADD CONSTRAINT FK_ActorDirector FOREIGN KEY(idDirector) REFERENCES Director(idDirector)
--ASISTENTEANIMACION
ALTER TABLE AsistenteAnimacion ADD CONSTRAINT FK_AsistenteAnimacionDirector FOREIGN KEY(idDirector) REFERENCES Director(idDirector)
--ANIMACION
ALTER TABLE Animacion ADD CONSTRAINT FK_AnimacionAsistenteAnimacion FOREIGN KEY(idAsistenteAnimacion) REFERENCES AsistenteAnimacion(idAsistenteAnimacion)
--ANIMADOR
ALTER TABLE Animador ADD CONSTRAINT FK_AnimadorDirector FOREIGN KEY(idDirector) REFERENCES Director(idDirector)
--ARTISTA
ALTER TABLE Artista ADD CONSTRAINT FK_ArtistaDirector FOREIGN KEY(idDirector) REFERENCES Director(idDirector)
--Colaboracion
ALTER TABLE Colaboracion ADD CONSTRAINT FK_ColaboracionJuntaDirectiva FOREIGN KEY(idJuntaDirectiva) REFERENCES JuntaDirectiva(idJuntaDirectiva)
--ColorScript
ALTER TABLE ColorScript ADD CONSTRAINT FK_ColorScriptArtista FOREIGN KEY(idArtista) REFERENCES Artista(idArtista)
--Tecnico
ALTER TABLE Tecnico ADD CONSTRAINT FK_TecnicoDirector FOREIGN KEY(idDirector) REFERENCES Director(idDirector)
--Compositing
ALTER TABLE Compositing ADD CONSTRAINT FK_CompositingTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
--CorreccionColor
ALTER TABLE CorreccionColor ADD CONSTRAINT FK_CorreccionColorTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
--DiaPresentacion
ALTER TABLE DiaPresentacion ADD CONSTRAINT FK_DiaPresentacionJuntaDirectiva FOREIGN KEY(idJuntaDirectiva) REFERENCES JuntaDirectiva(idJuntaDirectiva)
--Directivo
ALTER TABLE Directivo ADD CONSTRAINT FK_DirectivoJuntaDirectiva FOREIGN KEY(idJuntaDirectiva) REFERENCES JuntaDirectiva(idJuntaDirectiva)
--Esqueletizacion
ALTER TABLE Esqueletizacion ADD CONSTRAINT FK_EsqueletizacionTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
--Gerente
ALTER TABLE Gerente ADD CONSTRAINT FK_GerenteDirectivo FOREIGN KEY(idDirectivo) REFERENCES Directivo(idDirectivo)
--ExhibicionInternacional
ALTER TABLE ExhibicionInternacional ADD CONSTRAINT FK_ExhibicionInternacionalGerente FOREIGN KEY(idGerente) REFERENCES Gerente(idGerente)
--ExhibicionNacional
ALTER TABLE ExhibicionNacional ADD CONSTRAINT FK_ExhibicionNacionalGerente FOREIGN KEY(idGerente) REFERENCES Gerente(idGerente)
--Fondista
ALTER TABLE Fondista ADD CONSTRAINT FK_FondistaDirector FOREIGN KEY(idDirector) REFERENCES Director(idDirector)
--FxPersonaje
ALTER TABLE FxPersonaje ADD CONSTRAINT FK_FxPersonajeTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
--GrabacionVoz
ALTER TABLE GrabacionVoz ADD CONSTRAINT FK_GrabacionVozTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
--Guionista
ALTER TABLE Guionista ADD CONSTRAINT FK_GuionistaGerente FOREIGN KEY(idGerente) REFERENCES Gerente(idGerente)
--Guion
ALTER TABLE Guion ADD CONSTRAINT FK_GuionGuionista FOREIGN KEY(idGuionista) REFERENCES Guionista(idGuionista)
--Idea
ALTER TABLE Idea ADD CONSTRAINT FK_IdeaJuntaDirectiva FOREIGN KEY(idJuntaDirectiva) REFERENCES JuntaDirectiva(idJuntaDirectiva)
--Iluminacion
ALTER TABLE Iluminacion ADD CONSTRAINT FK_IluminacionTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
--Masterizacion
ALTER TABLE Masterizacion ADD CONSTRAINT FK_MasterizacionTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
--MattePainting
ALTER TABLE MattePainting ADD CONSTRAINT FK_MattePaintingFondista FOREIGN KEY(idFondista) REFERENCES Fondista(idFondista)
--Modelado
ALTER TABLE Modelado ADD CONSTRAINT FK_ModeladoAsistenteAnimacion FOREIGN KEY(idAsistenteAnimacion) REFERENCES AsistenteAnimacion(idAsistenteAnimacion)
--Musica
ALTER TABLE Musica ADD CONSTRAINT FK_MusicaTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
--Patrocinador
ALTER TABLE Patrocinador ADD CONSTRAINT FK_PatrocinadorJuntaDirectiva FOREIGN KEY(idJuntaDirectiva) REFERENCES JuntaDirectiva(idJuntaDirectiva)
--Pelicula
ALTER TABLE Pelicula ADD CONSTRAINT FK_PeliculaJuntaDirectiva FOREIGN KEY(idJuntaDirectiva) REFERENCES JuntaDirectiva(idJuntaDirectiva)
ALTER TABLE Pelicula ADD CONSTRAINT FK_PeliculaDirector FOREIGN KEY(idDirector) REFERENCES Director(idDirector)
--PreExhibicion
ALTER TABLE PreExhibicion ADD CONSTRAINT FK_PreExhibicionGerente FOREIGN KEY(idGerente) REFERENCES Gerente(idGerente)
--Presupuesto
ALTER TABLE Presupuesto ADD CONSTRAINT FK_PresupuestoGerente FOREIGN KEY(idGerente) REFERENCES Gerente(idGerente)
--Productor
ALTER TABLE Productor ADD CONSTRAINT FK_ProductorGerente FOREIGN KEY(idGerente) REFERENCES Gerente(idGerente)
ALTER TABLE Productor ADD CONSTRAINT FK_ProductorDirector FOREIGN KEY(idDirector) REFERENCES Director(idDirector)
--Pubilicidad
ALTER TABLE Publicidad ADD CONSTRAINT FK_PubilicidadGerente FOREIGN KEY(idGerente) REFERENCES Gerente(idGerente)
--PulidoCamara
ALTER TABLE PulidoCamara ADD CONSTRAINT FK_PulidoCamaraTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
--Rediseño
ALTER TABLE Rediseño ADD CONSTRAINT FK_RediseñoDirector FOREIGN KEY(idDirector) REFERENCES Director(idDirector)
--Revision
ALTER TABLE Revision ADD CONSTRAINT FK_RevisionDirector FOREIGN KEY(idDirector) REFERENCES Director(idDirector)
--SetDressing
ALTER TABLE SetDressing ADD CONSTRAINT FK_SetDressingFondista FOREIGN KEY(idFondista) REFERENCES Fondista(idFondista)
--SFX
ALTER TABLE SFX ADD CONSTRAINT FK_SFXTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
--Texturizado
ALTER TABLE Texturizado ADD CONSTRAINT FK_TexturizadoTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
--ActorGrabacionVoz
ALTER TABLE ActorGrabacionVoz ADD CONSTRAINT FK_ActorGrabacionVozActor FOREIGN KEY(idActor) REFERENCES Actor(idActor)
ALTER TABLE ActorGrabacionVoz ADD CONSTRAINT FK_ActorGrabacionVozGrabacionVoz FOREIGN KEY(idGrabacionVoz) REFERENCES GrabacionVoz(idGrabacionVoz)
--AnimacionANimador
ALTER TABLE AnimacionAnimador ADD CONSTRAINT FK_AnimacionAnimadorAnimacion FOREIGN KEY(idAnimacion) REFERENCES Animacion(idAnimacion)
ALTER TABLE AnimacionAnimador ADD CONSTRAINT FK_AnimacionAnimadorAnimador FOREIGN KEY(idAnimador) REFERENCES Animador(idAnimador)
--AnimadorAnimatic 2D
ALTER TABLE AnimadorAnimatic2D ADD CONSTRAINT FK_AnimadorAnimatic2DAnimador FOREIGN KEY(idAnimador) REFERENCES Animador(idAnimador)
ALTER TABLE AnimadorAnimatic2D ADD CONSTRAINT FK_AnimadorAnimatic2DAnimatic2D FOREIGN KEY(idAnimatic2D) REFERENCES Animatic2D(idAnimatic2D)
--AnimadorModelo
ALTER TABLE AnimadorModelo ADD CONSTRAINT FK_AnimadorModeloAnimador FOREIGN KEY(idAnimador) REFERENCES Animador(idAnimador)
ALTER TABLE AnimadorModelo ADD CONSTRAINT FK_AnimadorModeloModelado FOREIGN KEY(idModelado) REFERENCES Modelado(idModelado)
--ArtistaAreaConceptual
ALTER TABLE ArtistaAreaConceptual ADD CONSTRAINT FK_ArtistaAreaConceptualArtista FOREIGN KEY(idArtista) REFERENCES Artista(idArtista)
ALTER TABLE ArtistaAreaConceptual ADD CONSTRAINT FK_ArtistaAreaConceptualArteConceptual FOREIGN KEY(idArteConceptual) REFERENCES ArteConceptual(idArteConceptual)
--ArtistaStoryBoard
ALTER TABLE ArtistaStoryBoard ADD CONSTRAINT FK_ArtistaStoryBoardArtista FOREIGN KEY(idArtista) REFERENCES Artista(idArtista)
ALTER TABLE ArtistaStoryBoard ADD CONSTRAINT FK_ArtistaStoryBoardStoryBoard FOREIGN KEY(idStoryBoard) REFERENCES StoryBoard(idStoryBoard)
--CambioDirectivo
ALTER TABLE CambioDirectivo ADD CONSTRAINT FK_CambioDirectivoCambio FOREIGN KEY(idCambio) REFERENCES Cambio(idCambio)
ALTER TABLE CambioDirectivo ADD CONSTRAINT FK_CambioDirectivoDirectivo FOREIGN KEY(idDirectivo) REFERENCES Directivo(idDirectivo)
--DirectorGerente
ALTER TABLE DirectorGerente ADD CONSTRAINT FK_DirectorGerenteDirector FOREIGN KEY(idDirector) REFERENCES Director(idDirector)
ALTER TABLE DirectorGerente ADD CONSTRAINT FK_DirectorGerenteGerente FOREIGN KEY(idGerente) REFERENCES Gerente(idGerente)
--IngresoExhibicionInternacional
ALTER TABLE IngresoExhibicionInternacional ADD CONSTRAINT FK_IngresoExhibicionInternacionalIngreso FOREIGN KEY(idIngreso) REFERENCES Ingreso(idIngreso)
ALTER TABLE IngresoExhibicionInternacional ADD CONSTRAINT FK_IngresoExhibicionInternacionalExhibicionInternacional FOREIGN KEY(idExhibicionInternacional) REFERENCES ExhibicionInternacional(idExhibicionInternacional)
--IngresoExhibicionNacional
ALTER TABLE IngresoExhibicionNacional ADD CONSTRAINT FK_IngresoExhibicionNacionalIngreso FOREIGN KEY(idIngreso) REFERENCES Ingreso(idIngreso)
ALTER TABLE IngresoExhibicionNacional ADD CONSTRAINT FK_IngresoExhibicionNacionalExhibicionNacional FOREIGN KEY(idExhibicionNacional) REFERENCES ExhibicionNacional(idExhibicionNacional)
--LayoutTecnico
ALTER TABLE LayoutTecnico ADD CONSTRAINT FK_LayoutTecnicoLayout FOREIGN KEY(idLayout) REFERENCES Layout(idLayout)
ALTER TABLE LayoutTecnico ADD CONSTRAINT FK_LayoutTecnicoTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
--MusicaMusico
ALTER TABLE MusicaMusico ADD CONSTRAINT FK_MusicaMusicoMusica FOREIGN KEY(idMusica) REFERENCES Musica(idMusica)
ALTER TABLE MusicaMusico ADD CONSTRAINT FK_MusicaMusicoMusico FOREIGN KEY(idMusico) REFERENCES Musico(idMusico)
--PostProduccionTecnico
ALTER TABLE PostProduccionTecnico ADD CONSTRAINT FK_PostProduccionTecnicoPostProduccion FOREIGN KEY(idPostProduccion) REFERENCES PostProduccion(idPostProduccion)
ALTER TABLE PostProduccionTecnico ADD CONSTRAINT FK_PostProduccionTecnicoTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
--VFXTecnico
ALTER TABLE VFXTecnico ADD CONSTRAINT FK_VFXTecnicoTecnico FOREIGN KEY(idTecnico) REFERENCES Tecnico(idTecnico)
ALTER TABLE VFXTecnico ADD CONSTRAINT FK_VFXTecnicoVFX FOREIGN KEY(idVFX) REFERENCES VFX(idVFX)

--INDICES
CREATE INDEX TX_Animatic2D ON Animatic2D(idAnimatic2D)
CREATE INDEX TX_ArteConceptual ON ArteConceptual(idArteConceptual)
CREATE INDEX TX_Cambio ON Cambio(idCambio)
CREATE INDEX TX_Director ON Director(idDirector)
CREATE INDEX TX_Ingreso ON Ingreso(idIngreso)
CREATE INDEX TX_JuntaDirectiva ON JuntaDirectiva(idJuntaDirectiva)
CREATE INDEX TX_Layout ON Layout(idLayout)
CREATE INDEX TX_Musico ON Musico(idMusico)
CREATE INDEX TX_PostProduccion ON PostProduccion(idPostProduccion)
CREATE INDEX TX_StoryBoard ON StoryBoard(idStoryBoard)
CREATE INDEX TX_VFX ON VFX(idVFX)
CREATE INDEX TX_Actor ON Actor(idActor)
CREATE INDEX TX_AsistenteAnimacion ON AsistenteAnimacion(idAsistenteAnimacion)
CREATE INDEX TX_Animacion ON Animacion (idAnimacion)
CREATE INDEX TX_Animador ON Animador(idAnimador)
CREATE INDEX TX_Artista ON Artista(idArtista)
CREATE INDEX TX_Colaboracion ON Colaboracion(idColaboracion)
CREATE INDEX TX_ColorScript ON ColorScript(idColorScript)
CREATE INDEX TX_Tecnico ON Tecnico(idTecnico)
CREATE INDEX TX_Compositing ON Compositing(idCompositing)
CREATE INDEX TX_CorreccionColor ON CorreccionColor(idCorreccionColor)
CREATE INDEX TX_DiaPresentacion ON DiaPresentacion(idDiaPresentacion)
CREATE INDEX TX_Directivo ON Directivo(idDirectivo)
CREATE INDEX TX_Esqueletizacion ON Esqueletizacion(idEsqueletizacion)
CREATE INDEX TX_Gerente ON Gerente(idGerente)
CREATE INDEX TX_ExhibicionInternacional ON ExhibicionInternacional(idExhibicionInternacional)
CREATE INDEX TX_ExhibicionNacional ON ExhibicionNacional(idExhibicionNacional)
CREATE INDEX TX_Fondista ON Fondista(idFondista)
CREATE INDEX TX_FxPersonaje ON FxPersonaje(idFxPersonaje)
CREATE INDEX TX_GrabacionVoz ON GrabacionVoz(idGrabacionVoz)
CREATE INDEX TX_Guionista ON Guionista(idGuionista)
CREATE INDEX TX_Guion ON Guion(idGuion)
CREATE INDEX TX_Idea ON Idea(idIdea)
CREATE INDEX TX_Iluminacion ON Iluminacion(idIluminacion)
CREATE INDEX TX_Masterizacion ON Masterizacion(idMasterizacion)
CREATE INDEX TX_MattePainting ON MattePainting(idMattePainting)
CREATE INDEX TX_Modelado ON Modelado(idModelado)
CREATE INDEX TX_Musica ON Musica(idMusica)
CREATE INDEX TX_Patrocinador ON Patrocinador(idPatrocinador)
CREATE INDEX TX_Pelicula ON Pelicula(idPelicula)
CREATE INDEX TX_PreExhibicion ON PreExhibicion(idPreExhibicion)
CREATE INDEX TX_Presupuesto ON Presupuesto(idPresupuesto)
CREATE INDEX TX_Productor ON Productor(idProductor)
CREATE INDEX TX_Publicidad ON Publicidad(idPublicidad)
CREATE INDEX TX_PulidoCamara ON PulidoCamara(idPulidoCamara)
CREATE INDEX TX_Rediseño ON Rediseño(idRediseño)
CREATE INDEX TX_Revision ON Revision(idRevision)
CREATE INDEX TX_SetDressing ON SetDressing(idSetDressing)
CREATE INDEX TX_SFX ON SFX(idSFX)
CREATE INDEX TX_Texturizado ON Texturizado(idTexturizado)
CREATE INDEX TX_ActorGrabacionVoz ON ActorGrabacionVoz(idActorGrabacionVoz)
CREATE INDEX TX_AnimacionAnimador ON AnimacionAnimador(idAnimacionAnimador)
CREATE INDEX TX_AnimadorAnimatic2D ON AnimadorAnimatic2D(idAnimadorAnimatic2D)
CREATE INDEX TX_AnimadorModelo ON AnimadorModelo(idAnimadorModelo)
CREATE INDEX TX_ArtistaArteConceptual ON ArtistaAreaConceptual(idArtistaAreaConceptual)
CREATE INDEX TX_ArtistaStoryBoard ON ArtistaStoryBoard(idArtistaStoryBoard)
CREATE INDEX TX_CambioDirectivo ON CambioDirectivo(idCambioDirectivo)
CREATE INDEX TX_DirectorGerente ON DirectorGerente(idDirectorGerente)
CREATE INDEX TX_IngresoExhibicionInternacional ON IngresoExhibicionInternacional(idIngresoExhibicionInternacional)
CREATE INDEX TX_IngrecioExhibicionNacional ON IngresoExhibicionNacional(idIngresoExhibicionNacional)
CREATE INDEX TX_LayoutTecnico ON LayoutTecnico(idLayoutTecnico)
CREATE INDEX TX_MusicaMusico ON MusicaMusico(idMusicaMusico)
CREATE INDEX TX_PostProduccionTecnico ON PostProduccionTecnico(idPostProduccionTecnico)
CREATE INDEX TX_VFXTecnico ON VFXTecnico(idVFXTecnico)

---DATOS 
INSERT INTO Animatic2D ( fechaEntrega, personaje) 
values 
('01/12/22','Personaje1'),
('02/12/22','Personaje1'),
('03/12/22','Personaje1'),
('04/12/22','Personaje1'),
('05/12/22','Personaje1'),
('06/12/22','Personaje1'),
('07/12/22','Personaje1'),
('08/12/22','Personaje1'),
('09/12/22','Personaje1'),
('10/12/22','Personaje1')
GO
INSERT INTO ArteConceptual (concepto, fechaEntrega)
values
('concepto1', '02/12/22'),
('concepto2', '03/12/22'),
('concepto3', '04/12/22'),
('concepto4', '05/12/22'),
('concepto5', '06/12/22'),
('concepto6', '07/12/22'),
('concepto7', '08/12/22'),
('concepto8', '09/12/22'),
('concepto9', '10/12/22'),
('concepto10','11/12/22')
GO
INSERT INTO Cambio (cambio, descripcion, fecha)
values
('cambio1','descripcion1','01/12/22'),
('cambio2','descripcion2','02/12/22'),
('cambio3','descripcion3','03/12/22'),
('cambio4','descripcion4','04/12/22'),
('cambio5','descripcion5','05/12/22'),
('cambio6','descripcion6','06/12/22'),
('cambio7','descripcion7','07/12/22'),
('cambio8','descripcion8','08/12/22'),
('cambio9','descripcion9','09/12/22'),
('cambio10','descripcion10','10/12/22')
GO
INSERT INTO Director (nombre, apellidoPaterno, apellidoMaterno)
values
('nombre1','apellidop1','apellidom1'),
('nombre2','apellidop2','apellidom2'),
('nombre3','apellidop3','apellidom3'),
('nombre4','apellidop4','apellidom4'),
('nombre5','apellidop5','apellidom5'),
('nombre6','apellidop6','apellidom6'),
('nombre7','apellidop7','apellidom7'),
('nombre8','apellidop8','apellidom8'),
('nombre9','apellidop9','apellidom9'),
('nombre10','apellidop10','apellidom10')
GO
INSERT INTO Ingreso (ingreso,descripcion)
values
('1','descripicion1'),
('2','descripicion2'),
('3','descripicion3'),
('4','descripicion4'),
('5','descripicion5'),
('6','descripicion6'),
('7','descripicion7'),
('8','descripicion8'),
('9','descripicion9'),
('10','descripicion10')
GO
INSERT INTO JuntaDirectiva (motivo,numIntegrantes)
values
('motivo1','1'),
('motivo2','2'),
('motivo3','3'),
('motivo4','4'),
('motivo5','5'),
('motivo6','6'),
('motivo7','7'),
('motivo8','8'),
('motivo9','9'),
('motivo10','10')
GO
INSERT INTO Layout (fechaEntrega, correccionDibujo,tipo)
values
('01/12/22','correccion1','tipo1'),
('01/12/22','correccion2','tipo2'),
('03/12/22','correccion3','tipo3'),
('04/12/22','correccion4','tipo4'),
('05/12/22','correccion5','tipo5'),
('06/12/22','correccion6','tipo6'),
('07/12/22','correccion7','tipo7'),
('08/12/22','correccion8','tipo8'),
('09/12/22','correccion9','tipo9'),
('10/12/22','correccion10','tipo10')
GO
INSERT INTO Musico (nombre, apellidoPaterno, apellidoMaterno,tipoMusica)
values
('nombre1','apellidop1','apellidom1','tipo1'),
('nombre2','apellidop2','apellidom2', 'tipo2'),
('nombre3','apellidop3','apellidom3','tipo3'),
('nombre4','apellidop4','apellidom4','tipo4'),
('nombre5','apellidop5','apellidom5','tipo5'),
('nombre6','apellidop6','apellidom6','tipo6'),
('nombre7','apellidop7','apellidom7','tipo7'),
('nombre8','apellidop8','apellidom8','tipo8'),
('nombre9','apellidop9','apellidom9','tipo9'),
('nombre10','apellidop10','apellidom10','tipo10')
GO
INSERT INTO PostProduccion (fechaEntrega, correccionFinal)
values
('01/12/22','cfinal1'),
('02/12/22','cfinal2'),
('03/12/22','cfinal3'),
('04/12/22','cfinal4'),
('05/12/22','cfinal5'),
('06/12/22','cfinal6'),
('07/12/22','cfinal7'),
('08/12/22','cfinal8'),
('09/12/22','cfinal9'),
('10/12/22','cfinal10')
GO
INSERT INTO StoryBoard (tituloEscena, ideaEscena,fechaEntrega)
values
('titulo1','idea1','01/12/22'),
('titulo2','idea2','02/12/22'),
('titulo3','idea3','03/12/22'),
('titulo4','idea4','04/12/22'),
('titulo5','idea5','05/12/22'),
('titulo6','idea6','06/12/22'),
('titulo7','idea7','07/12/22'),
('titulo8','idea8','08/12/22'),
('titulo9','idea9','09/12/22'),
('titulo10','idea10','10/12/22')
GO
INSERT INTO VFX (fechaEntrega, tipo)
values
('01/12/22','tipo1'),
('02/12/22','tipo2'),
('03/12/22','tipo3'),
('04/12/22','tipo4'),
('05/12/22','tipo5'),
('06/12/22','tipo6'),
('07/12/22','tipo7'),
('08/12/22','tipo8'),
('09/12/22','tipo9'),
('10/12/22','tipo10')
GO
INSERT INTO Actor (nombre, apellidoPaterno, apellidoMaterno,personaje, idDirector)
values
('nombre1','apellidop1','apellidom1','personaje1',1),
('nombre2','apellidop2','apellidom2','personaje2',1),
('nombre3','apellidop3','apellidom3','personaje3',1),
('nombre4','apellidop4','apellidom4','personaje4',1),
('nombre5','apellidop5','apellidom5','personaje5',1),
('nombre6','apellidop6','apellidom6','personaje6',1),
('nombre7','apellidop7','apellidom7','personaje7',1),
('nombre8','apellidop8','apellidom8','personaje8',1),
('nombre9','apellidop9','apellidom9','personaje9',1),
('nombre10','apellidop10','apellidom10','personaje10',1)
GO
INSERT INTO AsistenteAnimacion (nombre, apellidoPaterno, apellidoMaterno,idDirector)
values
('nombre1','apellidop1','apellidom1',1),
('nombre2','apellidop2','apellidom2',1),
('nombre3','apellidop3','apellidom3',1),
('nombre4','apellidop4','apellidom4',1),
('nombre5','apellidop5','apellidom5',1),
('nombre6','apellidop6','apellidom6',1),
('nombre7','apellidop7','apellidom7',1),
('nombre8','apellidop8','apellidom8',1),
('nombre9','apellidop9','apellidom9',1),
('nombre10','apellidop10','apellidom10',1)
GO
INSERT INTO Animacion (nombre,fechaEntrega, idAsistenteAnimacion)
values
('nombre1','01/12/22',1),
('nombre2','02/12/22',1),
('nombre3','03/12/22',1),
('nombre4','04/12/22',1),
('nombre5','05/12/22',1),
('nombre6','06/12/22',1),
('nombre7','07/12/22',1),
('nombre8','08/12/22',1),
('nombre9','09/12/22',1),
('nombre10','10/12/22',1)
GO
INSERT INTO Animador (nombre, apellidoPaterno, apellidoMaterno, especializacion, idDirector)
values
('nombre1','apellidop1','apellidom1','especializacion1',1),
('nombre2','apellidop2','apellidom2','especializacion2',1),
('nombre3','apellidop3','apellidom3','especializacion3',1),
('nombre4','apellidop4','apellidom4','especializacion4',1),
('nombre5','apellidop5','apellidom5','especializacion5',1),
('nombre6','apellidop6','apellidom6','especializacion6',1),
('nombre7','apellidop7','apellidom7','especializacion7',1),
('nombre8','apellidop8','apellidom8','especializacion8',1),
('nombre9','apellidop9','apellidom9','especializacion9',1),
('nombre10','apellidop10','apellidom10','especializacion10',1)
GO
INSERT INTO Artista (nombre, apellidoPaterno, apellidoMaterno,especializacion, idDirector)
values
('nombre1','apellidop1','apellidom1','especializacion1',1),
('nombre2','apellidop2','apellidom2','especializacion2',1),
('nombre3','apellidop3','apellidom3','especializacion3',1),
('nombre4','apellidop4','apellidom4','especializacion4',1),
('nombre5','apellidop5','apellidom5','especializacion5',1),
('nombre6','apellidop6','apellidom6','especializacion6',1),
('nombre7','apellidop7','apellidom7','especializacion7',1),
('nombre8','apellidop8','apellidom8','especializacion8',1),
('nombre9','apellidop9','apellidom9','especializacion9',1),
('nombre10','apellidop10','apellidom10','especializacion10',1)
GO
INSERT INTO Colaboracion (estudio,numIntegrantes,idJuntaDirectiva)
values
('estudio1','10',1),
('estudio2','10',1),
('estudio3','10',1),
('estudio4','10',1),
('estudio5','10',1),
('estudio6','10',1),
('estudio7','10',1),
('estudio8','10',1),
('estudio9','10',1),
('estudio10','10',1)
GO
INSERT INTO ColorScript (descripcion,fechaEntrega,idArtista)
values
('descripcion1','01/12/22',1),
('descripcion2','02/12/22',1),
('descripcion3','03/12/22',1),
('descripcion4','04/12/22',1),
('descripcion5','05/12/22',1),
('descripcion6','06/12/22',1),
('descripcion7','07/12/22',1),
('descripcion8','08/12/22',1),
('descripcion9','09/12/22',1)
GO
INSERT INTO Tecnico (nombre, apellidoPaterno, apellidoMaterno, especializacion, idDirector)
values
('nombre1','apellidop1','apellidom1','especializacion1',1),
('nombre2','apellidop2','apellidom2','especializacion2',1),
('nombre3','apellidop3','apellidom3','especializacion3',1),
('nombre4','apellidop4','apellidom4','especializacion4',1),
('nombre5','apellidop5','apellidom5','especializacion5',1),
('nombre6','apellidop6','apellidom6','especializacion6',1),
('nombre7','apellidop7','apellidom7','especializacion7',1),
('nombre8','apellidop8','apellidom8','especializacion8',1),
('nombre9','apellidop9','apellidom9','especializacion9',1),
('nombre10','apellidop10','apellidom10','especializacion10',1)
GO
INSERT INTO Compositing (fechaEntrega,idTecnico)
values
('01/12/22',1),
('02/12/22',1),
('03/12/22',1),
('04/12/22',1),
('05/12/22',1),
('06/12/22',1),
('07/12/22',1),
('08/12/22',1),
('09/12/22',1),
('10/12/22',1)
GO
INSERT INTO CorreccionColor (descripcion, fechaEntrega, idTecnico)
values
('descripcion1','01/12/22',1),
('descripcion2','02/12/22',1),
('descripcion3','03/12/22',1),
('descripcion4','04/12/22',1),
('descripcion5','05/12/22',1),
('descripcion6','06/12/22',1),
('descripcion7','07/12/22',1),
('descripcion8','08/12/22',1),
('descripcion9','09/12/22',1),
('descripcion10','10/12/22',1)
GO
INSERT INTO DiaPresentacion (descripcion,fecha,idJuntaDirectiva)
values
('descripcion1','01/12/22',1),
('descripcion2','02/12/22',1),
('descripcion3','03/12/22',1),
('descripcion4','04/12/22',1),
('descripcion5','05/12/22',1),
('descripcion6','06/12/22',1),
('descripcion7','07/12/22',1),
('descripcion8','08/12/22',1),
('descripcion9','09/12/22',1),
('descripcion10','10/12/22',1)
GO
INSERT INTO Directivo (nombre,apellidoPaterno,apellidoMaterno, departamento,idJuntaDirectiva)
values
('nombre1','apellidop1','apellidom1','departamento1',1),
('nombre2','apellidop2','apellidom2','departamento2',1),
('nombre3','apellidop3','apellidom3','departamento3',1),
('nombre4','apellidop4','apellidom4','departamento4',1),
('nombre5','apellidop5','apellidom5','departamento5',1),
('nombre6','apellidop6','apellidom6','departamento6',1),
('nombre7','apellidop7','apellidom7','departamento7',1),
('nombre8','apellidop8','apellidom8','departamento8',1),
('nombre9','apellidop9','apellidom9','departamento9',1),
('nombre10','apellidop10','apellidom10','departamento10',1)
GO
INSERT INTO Esqueletizacion (fechaEntrega,idTecnico)
values
('01/12/22',1),
('02/12/22',1),
('03/12/22',1),
('04/12/22',1),
('05/12/22',1),
('06/12/22',1),
('07/12/22',1),
('08/12/22',1),
('09/12/22',1),
('10/12/22',1)
GO
INSERT INTO Gerente (nombre, apellidoPaterno, apellidoMaterno, departamento, idDirectivo)
values
('nombre1','apellidop1','apellidom1','departamento1',1),
('nombre2','apellidop2','apellidom2','departamento2',1),
('nombre3','apellidop3','apellidom3','departamento3',1),
('nombre4','apellidop4','apellidom4','departamento4',1),
('nombre5','apellidop5','apellidom5','departamento5',1),
('nombre6','apellidop6','apellidom6','departamento6',1),
('nombre7','apellidop7','apellidom7','departamento7',1),
('nombre8','apellidop8','apellidom8','departamento8',1),
('nombre9','apellidop9','apellidom9','departamento9',1),
('nombre10','apellidop10','apellidom10','departamento10',1)
GO
INSERT INTO ExhibicionInternacional (feha, calle, numero, colonia, ciudad, pais, idGerente)
values
('01/12/22','calle1','1','colonia1','ciudad1','pais1',1),
('02/12/22','calle2','1','colonia2','ciudad2','pais2',1),
('03/12/22','calle3','1','colonia3','ciudad3','pais3',1),
('04/12/22','calle4','1','colonia4','ciudad4','pais4',1),
('05/12/22','calle5','1','colonia5','ciudad5','pais5',1),
('06/12/22','calle6','1','colonia6','ciudad6','pais6',1),
('07/12/22','calle7','1','colonia7','ciudad7','pais7',1),
('08/12/22','calle8','1','colonia8','ciudad8','pais8',1),
('09/12/22','calle9','1','colonia9','ciudad9','pais9',1),
('10/12/22','calle10','1','colonia10','ciudad10','pais10',1)
GO
INSERT INTO ExhibicionNacional  (feha,calle,numero,colonia,ciudad,codigoPostal,idGerente)
values
('01/12/22','calle1','1','colonia1','ciudad1','cp1',1),
('02/12/22','calle2','2','colonia2','ciudad2','cp2',1),
('03/12/22','calle3','3','colonia3','ciudad3','cp3',1),
('04/12/22','calle4','4','colonia4','ciudad4','cp4',1),
('05/12/22','calle5','5','colonia5','ciudad5','cp5',1),
('06/12/22','calle6','6','colonia6','ciudad6','cp6',1),
('07/12/22','calle7','7','colonia7','ciudad7','cp7',1),
('08/12/22','calle8','8','colonia8','ciudad8','cp8',1),
('09/12/22','calle9','9','colonia9','ciudad9','cp9',1),
('10/12/22','calle10','10','colonia10','ciudad10','cp10',1)
GO
INSERT INTO Fondista (nombre, apellidoPaterno, apellidoMaterno, idDirector)
values
('nombre1','apellidop1','apellidom1',1),
('nombre2','apellidop2','apellidom2',1),
('nombre3','apellidop3','apellidom3',1),
('nombre4','apellidop4','apellidom4',1),
('nombre5','apellidop5','apellidom5',1),
('nombre6','apellidop6','apellidom6',1),
('nombre7','apellidop7','apellidom7',1),
('nombre8','apellidop8','apellidom8',1),
('nombre9','apellidop9','apellidom9',1),
('nombre10','apellidop10','apellidom10',1)
GO
INSERT INTO FxPersonaje (fechaEntrega,idTecnico)
values
('01/12/22',1),
('02/12/22',1),
('03/12/22',1),
('04/12/22',1),
('05/12/22',1),
('06/12/22',1),
('07/12/22',1),
('08/12/22',1),
('09/12/22',1),
('10/12/22',1)
GO
INSERT INTO  GrabacionVoz (fechaEntrega, idTecnico)
values
('01/12/22',1),
('02/12/22',1),
('03/12/22',1),
('04/12/22',1),
('05/12/22',1),
('06/12/22',1),
('07/12/22',1),
('08/12/22',1),
('09/12/22',1),
('10/12/22',1)
GO
INSERT INTO Guionista (nombre, apellidoPaterno, apellidoMaterno, idGerente)
values
('nombre1','apellidop1','apellidom1',1),
('nombre2','apellidop2','apellidom2',1),
('nombre3','apellidop3','apellidom3',1),
('nombre4','apellidop4','apellidom4',1),
('nombre5','apellidop5','apellidom5',1),
('nombre6','apellidop6','apellidom6',1),
('nombre7','apellidop7','apellidom7',1),
('nombre8','apellidop8','apellidom8',1),
('nombre9','apellidop9','apellidom9',1),
('nombre10','apellidop10','apellidom10',1)
GO
INSERT INTO Guion (titulo, fechaEntrega, idGuionista)
values
('titulo1','01/12/22',1),
('titulo2','02/12/22',1),
('titulo3','03/12/22',1),
('titulo4','04/12/22',1),
('titulo5','05/12/22',1),
('titulo6','06/12/22',1),
('titulo7','07/12/22',1),
('titulo8','08/12/22',1),
('titulo9','09/12/22',1),
('titulo10','10/12/22',1)
GO
INSERT INTO Idea (propuesta, fechaEntrega, idJuntaDirectiva)
values
('propuesta1','01/12/22',1),
('propuesta2','02/12/22',1),
('propuesta3','03/12/22',1),
('propuesta4','04/12/22',1),
('propuesta5','05/12/22',1),
('propuesta6','06/12/22',1),
('propuesta7','07/12/22',1),
('propuesta8','08/12/22',1),
('propuesta9','09/12/22',1),
('propuesta10','10/12/22',1)
GO
INSERT INTO Iluminacion (fechaEntrega,descripcion,idTecnico)
values
('01/12/11','descripcion1', 1),
('02/12/11','descripcion1', 1),
('03/12/11','descripcion1', 1),
('04/12/11','descripcion1', 1),
('05/12/11','descripcion1', 1),
('06/12/11','descripcion1', 1),
('07/12/11','descripcion1', 1),
('08/12/11','descripcion1', 1),
('09/12/11','descripcion1', 1),
('10/12/11','descripcion1', 1)
GO
INSERT INTO Masterizacion (fechaEntrega,tipoAudio, idTecnico)
values
('01/12/22','audio1',1),
('02/12/22','audio2',1),
('03/12/22','audio3',1),
('04/12/22','audio4',1),
('05/12/22','audio5',1),
('06/12/22','audio6',1),
('07/12/22','audio7',1),
('08/12/22','audio8',1),
('09/12/22','audio9',1),
('10/12/22','audio10',1)
GO
INSERT INTO MattePainting (fechaEntrega,idFondista)
values
('01/12/22',1),
('02/12/22',1),
('03/12/22',1),
('04/12/22',1),
('05/12/22',1),
('06/12/22',1),
('07/12/22',1),
('08/12/22',1),
('09/12/22',1),
('10/12/22',1)
GO
INSERT INTO Modelado (fechaEntrega, idAsistenteAnimacion)
values
('01/12/22',1),
('02/12/22',1),
('03/12/22',1),
('04/12/22',1),
('05/12/22',1),
('06/12/22',1),
('07/12/22',1),
('08/12/22',1),
('09/12/22',1),
('10/12/22',1)
GO
INSERT INTO Musica (nombre, genero,fechaEntrega, idTecnico)
values
('nombre1','genero1','01/12/22',1),
('nombre2','genero2','02/12/22',1),
('nombre3','genero3','03/12/22',1),
('nombre4','genero4','04/12/22',1),
('nombre5','genero5','05/12/22',1),
('nombre6','genero6','06/12/22',1),
('nombre7','genero7','07/12/22',1),
('nombre8','genero8','08/12/22',1),
('nombre9','genero9','09/12/22',1),
('nombre10','genero10','10/12/22',1)
GO
INSERT INTO Patrocinador (nombre, apellidoPaterno, apellidoMaterno, empresa, idJuntaDirectiva)
values
('nombre1','apellidop1','apellidom1','EMPRESA1',1),
('nombre2','apellidop2','apellidom2','empresa2',1),
('nombre3','apellidop3','apellidom3','empresa3',1),
('nombre4','apellidop4','apellidom4','empresa4',1),
('nombre5','apellidop5','apellidom5','empresa5',1),
('nombre6','apellidop6','apellidom6','empresa6',1),
('nombre7','apellidop7','apellidom7','empresa7',1),
('nombre8','apellidop8','apellidom8','empresa8',1),
('nombre9','apellidop9','apellidom9','empresa9',1),
('nombre10','apellidop10','apellidom10','empresa10',1)
GO
INSERT INTO Pelicula (titulo, genero, clasificacion,duracion, idJuntaDirectiva, idDirector)
values
('titulo1','genero1','A','130',1,2),
('titulo2','genero1','A','123',1,2),
('titulo3','genero1','A','60',1,2),
('titulo4','genero1','A','80',1,2),
('titulo5','genero1','A','70',1,2),
('titulo6','genero1','A','60',1,2),
('titulo7','genero1','A','100',1,2),
('titulo8','genero1','A','110',1,2),
('titulo9','genero1','A','120',1,2),
('titulo10','genero1','A','120',1,2)
GO
INSERT INTO PreExhibicion(feha,calle,numero,colonia,ciudad,codigoPostal,numParticipantes,idGerente)
values
('01/12/22','calle1','1','colonia','ciudad1','23122',1,2),
('02/12/22','calle2','2','colonia1','ciudad1','23122',1,2),
('03/12/22','calle3','4','colonia2','ciudad1','23122',1,2),
('04/12/22','calle4','5','colonia3','ciudad1','23122',1,2),
('05/12/22','calle5','6','colonia4','ciudad1','23122',1,2),
('06/12/22','calle6','3','colonia5','ciudad1','23122',1,2),
('07/12/22','calle7','4','colonia6','ciudad1','23122',1,2),
('08/12/22','calle8','8','colonia7','ciudad1','23122',1,2),
('09/12/22','calle9','86','colonia8','ciudad1','23122',1,2)
GO
INSERT INTO Presupuesto (desarrolloInv,areaTecnica,areaArtistica,marketing,idGerente)
values
(5000,245,3235,5456,2),
(1254,1235,8752,4567,3),
(12654,1235,8752,4567,4),
(1245,1235,8752,4567,5),
(1245,1235,8752,4567,2),
(12323,1335,8752,4567,2),
(1234,1235,8752,4567,4),
(12434,1235,8752,4567,3),
(1223,1235,8752,4567,2),
(1223,1235,8752,4567,1),
(1244,1235,8752,4567,2)
GO
INSERT INTO Productor(nombre,apellidoPaterno,apellidoMaterno,idGerente, idDirector)
values
('nombre1','ap1','am1',1,2),
('nombre2','ap2','am2',1,2),
('nombre3','ap3','am3',1,2),
('nombre4','ap4','am4',1,2),
('nombre5','ap5','am5',1,2),
('nombre6','ap6','am6',1,2),
('nombre7','ap7','am7',1,2),
('nombre8','ap8','am8',1,2),
('nombre9','ap9','am9',1,2),
('nombre10','ap10','am10',1,2)
GO
INSERT INTO Publicidad (medioTransimicion, precio, idGerente)
values
('medio1',2341,1),
('medio2',2231,1),
('medio3',2131,1),
('medio4',2231,1),
('medio5',2231,1),
('medio6',2541,1),
('medio7',2551,1),
('medio8',2661,1),
('medio9',2321,1),
('medio10',7641,1)
GO
INSERT INTO PulidoCamara (fechaEntrega, detalles, idTecnico)
values
('01/12/22','detalles1',1),
('02/12/22','detalles2',1),
('03/12/22','detalles3',1),
('04/12/22','detalles4',1),
('05/12/22','detalles5',1),
('06/12/22','detalles6',1),
('07/12/22','detalles7',1),
('08/12/22','detalles8',1),
('06/12/22','detalles9',1),
('08/12/22','detalles10',1)
GO
INSERT INTO Rediseño (primerRediseño, segundoRediseño, idDirector)
values
('01/12/22','02/12/23',1),
('02/12/22','03/12/23',1),
('03/12/22','04/12/23',1),
('04/12/22','05/12/23',1),
('05/12/22','06/12/23',1),
('06/12/22','06/12/23',1),
('07/12/22','07/12/23',1),
('08/12/22','08/12/23',1),
('09/12/22','09/12/23',1),
('10/12/22','07/12/23',1)
GO
INSERT INTO Revision (primeraRevision, segundaRevision, idDirector)
values
('01/12/22','02/12/23',1),
('02/12/22','03/12/23',1),
('03/12/22','04/12/23',1),
('04/12/22','05/12/23',1),
('05/12/22','06/12/23',1),
('06/12/22','06/12/23',1),
('07/12/22','07/12/23',1),
('08/12/22','08/12/23',1),
('09/12/22','09/12/23',1),
('10/12/22','07/12/23',1)
GO
INSERT INTO SetDressing (fechaEntrega,idFondista)
values
('01/12/22',1),
('02/12/22',1),
('03/12/22',1),
('04/12/22',1),
('05/12/22',1),
('06/12/22',1),
('07/12/22',1),
('08/12/22',1),
('09/12/22',1),
('10/12/22',1)
GO
INSERT INTO SFX(tipo, fechaEntrega, idTecnico)
values
('tipo1','01/12/22',1),
('tipo2','02/12/22',1),
('tipo3','03/12/22',1),
('tipo4','04/12/22',1),
('tipo5','05/12/22',1),
('tipo6','06/12/22',1),
('tipo7','07/12/22',1),
('tipo8','08/12/22',1),
('tipo9','09/12/22',1),
('tipo10','10/12/22',1)
GO
INSERT INTO Texturizado (tipo, fechaEntrega, idTecnico)
values
('tipo1','01/12/22',1),
('tipo2','02/12/22',1),
('tipo3','03/12/22',1),
('tipo4','04/12/22',1),
('tipo5','05/12/22',1),
('tipo6','06/12/22',1),
('tipo7','07/12/22',1),
('tipo8','08/12/22',1),
('tipo9','09/12/22',1),
('tipo10','10/12/22',1)
GO
INSERT INTO ActorGrabacionVoz (idActor, idGrabacionVoz, numIntegrantes)
values
(1,2,'1'),
(2,3,'4'),
(3,4,'13'),
(4,5,'3'),
(6,7,'4'),
(7,8,'10'),
(8,5,'9'),
(9,8,'8'),
(1,9,'6')
GO
INSERT INTO AnimacionAnimador(idAnimacion, idAnimador, numIntegrantes)
values
(1,2,'1'),
(2,3,'4'),
(3,4,'13'),
(4,5,'3'),
(6,7,'4'),
(7,8,'10'),
(8,5,'9'),
(9,8,'8'),
(1,9,'6')
GO



INSERT INTO AnimadorModelo (idAnimador, idModelado, numIntegrantes)
values
(1,2,'1'),
(2,3,'4'),
(3,4,'13'),
(4,5,'3'),
(6,7,'4'),
(7,8,'10'),
(8,5,'9'),
(9,8,'8'),
(1,9,'6')
GO
INSERT INTO ArtistaAreaConceptual (idArtista, idArteConceptual, numIntegrantes)
values
(1,2,'1'),
(2,3,'4'),
(3,4,'13'),
(4,5,'3'),
(6,7,'4'),
(7,8,'10'),
(8,5,'9'),
(9,8,'8'),
(1,9,'6')
GO
INSERT INTO ArtistaStoryBoard (idArtista, idStoryBoard, numIntegrantes)
values
(1,2,'1'),
(2,3,'4'),
(3,4,'13'),
(4,5,'3'),
(6,7,'4'),
(7,8,'10'),
(8,5,'9'),
(9,8,'8'),
(1,9,'6')
GO
INSERT INTO CambioDirectivo (idCambio, idDirectivo, numIntegrantes)
values
(1,2,'1'),
(2,3,'4'),
(3,4,'13'),
(4,5,'3'),
(6,7,'4'),
(7,8,'10'),
(8,5,'9'),
(9,8,'8'),
(1,9,'6')
GO
INSERT INTO DirectorGerente (idDirector, idGerente, numIntegrantes)
values
(1,2,'1'),
(2,3,'4'),
(3,4,'13'),
(4,5,'3'),
(6,7,'4'),
(7,8,'10'),
(8,5,'9'),
(9,8,'8'),
(1,9,'6')
GO
INSERT INTO IngresoExhibicionInternacional (idIngreso, idExhibicionInternacional,numIntegrantes)
values
(1,2,'1'),
(2,3,'4'),
(3,4,'13'),
(4,5,'3'),
(6,7,'4'),
(7,8,'10'),
(8,5,'9'),
(9,8,'8'),
(1,9,'6')
GO
INSERT INTO IngresoExhibicionNacional (idIngreso, idExhibicionNacional, numIntegrantes)
values
(1,2,'1'),
(2,3,'4'),
(3,4,'13'),
(4,5,'3'),
(6,7,'4'),
(7,8,'10'),
(8,5,'9'),
(9,8,'8'),
(1,9,'6')
GO
INSERT INTO LayoutTecnico(idLayout, idTecnico, numIntegrantes)
values
(1,2,'1'),
(2,3,'4'),
(3,4,'13'),
(4,5,'3'),
(6,7,'4'),
(7,8,'10'),
(8,5,'9'),
(9,8,'8'),
(1,9,'6')
GO
INSERT INTO MusicaMusico (idMusica, idMusico, numIntegrantes)
values
(1,2,'1'),
(2,3,'4'),
(3,4,'13'),
(4,5,'3'),
(6,7,'4'),
(7,8,'10'),
(8,5,'9'),
(9,8,'8'),
(1,9,'6')
GO
INSERT INTO PostProduccionTecnico (idPostProduccion, idTecnico, numIntegrantes)
values
(1,2,'1'),
(2,3,'4'),
(3,4,'13'),
(4,5,'3'),
(6,7,'4'),
(7,8,'10'),
(8,5,'9'),
(9,8,'8'),
(1,9,'6')
GO
