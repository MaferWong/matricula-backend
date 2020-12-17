Feature: RegistroCurso

@mytag
Scenario: Registro de Curso
	Given el nombre del curso es "Informatica"
	When registrando el curso
	Then el registro del curso es "Successful"