Feature: RegistroPais

@mytag
Scenario: Registro de Pais
	Given el nombre del pais es "Honduras"
	When registrando el pais
	Then el registro del pais es "Successful"