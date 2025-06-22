using System;

class Product
{
    private string _name;
    private decimal _price;
    private int _quantity;

    public Product(string name, decimal price, int quantity)
    {
        SetName(name);
        SetPrice(price);
        _quantity = quantity < 0 ? 0 : quantity;
    }

    public string Name
    {
        get => _name;
        set => SetName(value);
    }

    public decimal Price
    {
        get => _price;
        set => SetPrice(value);
    }

    public int Quantity => _quantity;

    public decimal TotalValue => _price * _quantity;

    private void SetName(string value)
    {
        if (!string.IsNullOrWhiteSpace(value))
            _name = value;
        else
            Console.WriteLine("Помилка: назва товару не може бути порожньою!");
    }

    private void SetPrice(decimal value)
    {
        if (value >= 0)
            _price = value;
        else
            Console.WriteLine("Помилка: ціна не може бути від'ємною!");
    }

    public void Restock(int amount)
    {
        if (amount > 0)
            _quantity += amount;
        else
            Console.WriteLine("Помилка: кількість постачання повинна бути додатною!");
    }

    public void Sell(int amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Помилка: кількість продажу повинна бути додатною!");
        }
        else if (amount > _quantity)
        {
            Console.WriteLine("Недостатньо товару на складі!");
        }
        else
        {
            _quantity -= amount;
        }
    }

    public string GetInfo()
    {
        return $"Товар: {_name}, Ціна: {_price} грн, Кількість: {_quantity}, Загальна вартість: {TotalValue} грн";
    }
}