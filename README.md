This repository contains the Community (Unofficial) PowerToys Run Plugin for 1Password, enabling quick access to 1Password entries via the PowerToys Run launcher.

**Features:**

- **Vault Integration**: Search and access 1Password vault entries.
- **Copy to Clipboard**: Copy usernames and passwords easily.
- **Customizable Settings**: Set up 1Password path and default vault in PowerToys settings.

![image](https://github.com/KairuDeibisu/PowerToysRunPlugin1Password/assets/34011041/3ddd04fd-a291-4ee7-a001-64d781595743)


**Prerequisites:**

Ensure you have installed:
- PowerToys v0.78 or higher.
- 1Password for Windows v8.## or higher.
- 1Password CLI v2.## or higher

# **Installation:**

### Install PowerToys
- TODO
### Install 1password CLI

## Windows
1. Download the [latest release of 1Password CLI](https://app-updates.agilebits.com/product_history/CLI2) and extract op.exe.
> [!TIP]
> [Learn how to verify its authenticity](https://app-updates.agilebits.com/product_history/CLI2)
2. Open PowerShell as an administrator.
3. Create a folder to move op.exe into. For example, `C:\Program Files\1Password CLI`.
```PowerShell
mkdir "C:\Program Files\1Password CLI"
```
4. Move the op.exe file to the new folder.
```PowerShell
mv ".\op.exe" "C:\Program Files\1Password CLI"
```
5.  Add the folder containing the op.exe file to your PATH.
6.  Search for Advanced System Settings in the Start menu.
7.  Select Environment Variables.
8.  In the System Variables section, select the PATH environment variable and click Edit.
9.  In the prompt, click New and add the directory where op.exe is located.
10. Sign out and back in to Windows for the change to take effect.
11. Check that 1Password CLI installed successfully:
```PowerShell
op --version
```

> [!NOTE]
> The install path for the 1Password CLI should be `C:\Program Files\1Password CLI` if you followed this guide.

### Install Plugin

1. Download the plugin from the [Releases page](https://github.com/KairuDeibisu/PowerToysRunPlugin1Password/releases).

![image](https://github.com/user-attachments/assets/abf3ae1d-5644-468d-a572-3dd90f61d384)

2. Exit Power Toys.

![image](https://github.com/user-attachments/assets/effa2a20-5564-4abd-8f22-59b7ee9b9129)

5. Extract the ZIP file to `%LOCALAPPDATA%\Microsoft\PowerToys\PowerToys Run\Plugins`.

![image](https://github.com/user-attachments/assets/8f1435e8-3deb-4dd1-8c41-4dea996cbc53)
![image](https://github.com/user-attachments/assets/649eb722-b753-416e-b8d6-e7c82a2e49b8)
![image](https://github.com/user-attachments/assets/c826f6e2-0f5b-44b4-a01e-908f25ccbc00)
![image](https://github.com/user-attachments/assets/42843a3e-ac40-4f2a-8d07-b6f6ff3b55a3)



  
7. Reopen Power Toys.
8. Configure settings.
9. Quit and reopen Power Toys.

> [!IMPORTANT]
> If no warnings show and there are no items loaded. Close and reopen PowerToys. [Know Issue](https://github.com/KairuDeibisu/PowerToysRunPlugin1Password/issues/8)

<img width="526" alt="image" src="https://github.com/KairuDeibisu/PowerToysRunPlugin1Password/assets/34011041/f41391e6-4037-40dd-beeb-c3e5a149620a">

# Legal Disclaimer

This repository and its contents are not affiliated with, endorsed by, or sponsored by Microsoft Corporation, 1Password, or any of their respective affiliates or subsidiaries. The Community (Unofficial) PowerToys Run Plugin for 1Password is developed and maintained by independent contributors. The use of the PowerToys, 1Password, and any associated logos or trademarks are for descriptive purposes only and do not imply any endorsement or affiliation.
