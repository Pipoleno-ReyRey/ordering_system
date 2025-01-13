using System.Text.RegularExpressions;

Console.Write("1 - sign in \n2 - sign up \noption: ");
string response = Console.ReadLine()!;
User user = new User(0,"","","","");

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


while(true){
    Console.Write("1 - products \n2 - cart \n3 - update user \noption: ");
    response = Console.ReadLine()!;

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

        Console.WriteLine("==========================");
        Console.WriteLine("5 - add product");
        Console.WriteLine("6 - update product");
        Console.WriteLine("8 - add product to cart");
        Console.Write("option: ");
        response = Console.ReadLine()!;

        if(response == "5"){
            Console.Write("name:");
            string name = Console.ReadLine()!;
            Console.Write("description:");
            string description = Console.ReadLine()!;
            Console.Write("price:");
            float price = float.Parse(Console.ReadLine()!);
            Console.Write("amount:");
            int amount = Int32.Parse(Console.ReadLine()!);

            Products product = await Products.PostProducts(name, description, price, amount);

            Console.WriteLine($"============={product.seriesNum}=============");
            Console.WriteLine($"name: {product.name}");
            Console.WriteLine($"description: {product.description}");
            Console.WriteLine($"price: {product.price}");
            Console.WriteLine($"amount: {product.amount}");
            Console.WriteLine("==========================");
        }

        if(response == "8"){
            Console.Write("product:");
            string product = Console.ReadLine()!;
            Console.Write("amount:");
            int amount = Int32.Parse(Console.ReadLine()!);
            var productAdded = await Cart.AddToCart(user.id, product, amount);
            Console.WriteLine("||");
            Console.Write("|| ");
            Console.Write(productAdded);
            Console.Write("|| ");
            Console.WriteLine("||");
        }

    } 
    else if(response == "2" ){

        Cart cart = await Cart.GetCart(user.id);
        Console.WriteLine("================shopping/ordering cart=================");
        foreach(ProductsDto product in cart.listProducts){
            Console.WriteLine($"product: {product.name}");
            Console.WriteLine($"amount: {product.amount}");
            Console.WriteLine($"count: {product.count}");
            Console.WriteLine("========================");
        }
        Console.WriteLine("==========");
        Console.WriteLine($"${cart.count}");
        Console.WriteLine("==========");
        Console.WriteLine("================shopping/ordering cart=================");
    } 
    else if(response == "3"){

        Console.Write("name:");
        string name = Console.ReadLine()!;
        Console.Write("address:");
        string address = Console.ReadLine()!;
        Console.Write("password:");
        string password = Console.ReadLine()!;
        var userUpdated = await User.UpdateUser(user.email!, user.password!, name, address, password);

        Console.WriteLine("||");
        Console.Write("|| ");
        Console.Write(userUpdated);
        Console.Write("|| ");
        Console.WriteLine("||");
    }
}



