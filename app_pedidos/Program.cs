Console.Write("1 - sign in \n2 - sign up \noption: ");
string response = Console.ReadLine()!;
User user;

if(response == "1"){
    Console.Write("email:");
    string email = Console.ReadLine()!;
    Console.Write("password:");
    string password = Console.ReadLine()!;
    user = await User.GetUser(email, password);
    Console.WriteLine("---------------------------------");
    Console.WriteLine($"name:{user.name} \naddress:{user.address} \nemail:{user.email} \npassword:{user.password}");
    Console.WriteLine("---------------------------------");

} else if(response == "2"){
    Console.Write("name:");
    string name = Console.ReadLine()!;
    Console.Write("address:");
    string address = Console.ReadLine()!;
    Console.Write("email:");
    string email = Console.ReadLine()!;
    Console.Write("password:");
    string password = Console.ReadLine()!;
    user = await User.CreateUser(name, address, email, password);
    Console.WriteLine("----------Created User-----------------------");
    Console.WriteLine($"name:{user.name} \naddress:{user.address} \nemail:{user.email} \npassword:{user.password}");
    Console.WriteLine("---------------------------------");
}

Console.Write("1 - products \n2 - cart \n3 - update user \noption: ");
string response2 = Console.ReadLine()!;

if(response == "1"){
    List<Products> products = await Products.GetProducts();
    foreach(Products product in products){
        Console.WriteLine($"============={product.seriesNum}=============");
        Console.WriteLine($"name: {product.name}");
        Console.WriteLine($"description: {product.description}");
        Console.WriteLine($"price: {product.price}");
        Console.WriteLine($"amount: {product.amount}");
        Console.WriteLine("==========================");
    }
}

