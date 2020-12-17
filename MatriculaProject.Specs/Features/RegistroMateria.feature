Feature: RegistroMateria

@mytag
Scenario: Registro de Materia
	Given el codigo de materia es "MAT101"
	Given el nombre de materia es "Introduccion al Algebra"
	Given el cursoId de la materia es 1
	When registrando la materia
	Then el registro de materia es "Successful"