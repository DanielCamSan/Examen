# 🎬 EXAMEN PRÁCTICO – ARQUITECTURA POR CAPAS, EF CORE Y RELACIONES
🕒 Duración total: 2 horas
✅ Modalidad: Grupal – con código en computadora
## 🧠 Temas evaluados:

	Arquitectura por capas (Controllers, Services, Repositories, DbContext)

	Entity Framework Core (Code First)

	Relaciones 1:1, 1:N, N:M

	Validaciones de dominio

	Lógica de negocio en Services

	Buenas prácticas (DTOs, asincronía, inyección de dependencias)

## 🧩 Contexto del Sistema

Usted está trabajando en una aplicación llamada CinePlus, para la gestión de funciones de cine, compra de boletos y fidelización.

El proyecto ya contiene:

	Entities creadas

	DbContext configurado

	Controllers implementados

	Interfaces de Repositories declaradas

	Dependencias registradas solo de repositorio en Program.cs

🚩 Su misión es implementar la lógica faltante en los Services y Repositories, y realizar ciertos cambios solicitados.

## 📌 Parte A – Implementaciones obligatorias (60%)
1. Implementar lógica en Repositories y services (EF Core)

Debe completar métodos marcados como // TODO aplicando EF Core:


MovieRepository:	AddActorAsync, RemoveActorAsync	
ScreeningRepository:	ExistsOverlapAsync	
TicketRepository:	SeatTakenAsync	
LoyaltyCardRepository:	GetByCustomerAsync	
MovieRepository:	GetDetailsAsync	

Debe utilizar correctamente DbContext, Include, AnyAsync, AddAsync, SaveChangesAsync.

Debe implementar la logica de los servicios

## 📌 Parte B – Cambios de relaciones (20%)

Se solicita modificar una relación:

🔄 Cambio solicitado:

Actualmente, un Customer puede tener una sola LoyaltyCard (1:1).
Debe cambiar esta relación a 1:N (un cliente puede tener múltiples tarjetas).

Debe:

	Modificar entity Customer y LoyaltyCard

	Actualizar relación en OnModelCreating

	Ajustar repositorios si es necesario

	Probar la creación correcta mediante un request

## 📌 Parte C – Validaciones de negocio en Services (20%)

Implemente la lógica faltante usando inyección de repositorios:

ScreeningService:	No permitir crear una función si existe otra que se solape en la misma sala
TicketService:	No permitir reservar un asiento ya ocupado para una función	
## 📤 BONUS (5%)

Agregar verificación de email único al crear Customer (utilizando repositorio correspondiente).

## 📎 Formato de Entrega

	Debe ejecutar el proyecto antes de entregar.

	Todos los métodos implementados deben estar sin errores.

	Al menos un ejemplo probado con Postman por cada caso.

Crear su rama con evaluacion/teamXX.

## 📊 Rúbrica de Evaluación

	Correcta implementación EF Core	
	Relaciones funcionales	
	Validaciones en Services	
	Lógica asincrónica	
	Buenas prácticas	

## 🎯 Objetivo Final

Al finalizar, el sistema debe garantizar integridad de datos:

No se puede solapar funciones.

No se puede duplicar actor en película.

No se pueden duplicar asientos.

Múltiples tarjetas de fidelidad por cliente.

Lógica de dominio aplicada en Services, no en Controllers.

## 📌 IMPORTANTE:
Copiar y pegar código de internet será penalizado. Cada implementación debe estar relacionada con la arquitectura entregada.