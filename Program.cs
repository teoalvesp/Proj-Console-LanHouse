static void Start()
{
    FrontendService.DisplayLogo();

    // Inicializar a LanHouse com o número de PCs
    LanHouse lanHouse = new LanHouse(5);

    // Login de Usuário
    FrontendService.Login();

    // Interação do Menu com o Usuário
    while (true)
    {
        // Chamar o menu e obter a opção selecionada e o número do desktop
        (MenuOption selectedOption, int desktopNumber) = FrontendService.Menu();

        // Switch para lidar com a opção escolhida
        switch (selectedOption)
        {
            case MenuOption.Rent:
                // aluga o desktop com número desktopNumber
                lanHouse.RentDesktop(desktopNumber);
                break;
            case MenuOption.Release:
                // libera o desktop com número desktopNumber
                lanHouse.ReleaseDesktop(desktopNumber);
                break;
            case MenuOption.DisplayStatus:
                // exibi o status dos PCs
                lanHouse.DisplayStatus();
                break;
            case MenuOption.Exit:
                // Encerra o programa
                Console.WriteLine("Encerrando o programa...");
                return; // Sai do método Main e encerrar o programa
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
}

Start();
