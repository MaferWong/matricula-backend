Feature: RegistroProfesor

@mytag
Scenario: Registro de profesores
	Given el nombre del profesor es "Josue"
	And la edad del profesor is 25
	And el sexo del profesor es "M"
	And el correo del profesor es "josue@gmail.com"
	And la contrasena del profesor es "Contrasena123"
	And el usuario del profesor isActive es "true"
	And el paisId del profesor es 1
	And el materiaId del profesor es 1
	When registrando el profesor
	Then el registro es "Successful"