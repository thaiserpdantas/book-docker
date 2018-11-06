$Server = "localhost,2433";
$User = "sa";
$Password = "Book#123";
$Timeout = 65534;
$Scripts=(
	"DatabaseMigration/CreateBookDatabase.sql"
);

docker-compose down

docker-compose up -d

Write-Output "Waiting until SqlServer is running..."
Start-Sleep -Seconds 15

Foreach ($script In $Scripts) {

	Write-Host "Executing $($script)";
	sqlcmd -S $Server -U $User -P $Password -l $Timeout -t $Timeout -i $script;
	Write-Host "Script execution completed.";
}

Write-Output "Process completed".