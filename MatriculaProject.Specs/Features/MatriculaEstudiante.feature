Feature: Matricula

@mytag
Scenario: Matricula de estudiantes
	Given el nombre del estudiante es "Fernarda"
	And la edad del estudiante is 19
	And el sexo del estudiante es "F"
	And el correo del estudiante es "mafer@gmail.com"
	And la contrasena del estudiante es "Contrasena123"
	And el usuario del estudiante isActive es "true"
	And el paisId del estudiante es 1
	And el cursoId del estudiante es 1
	When matriculando el estudiante
	Then la matricula es "Successful"
