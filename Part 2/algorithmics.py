import math


def is_palindrome(word: str) -> bool:
    return word == word[::-1]


def is_sorted(word: str) -> bool:
    return word == "".join(sorted(word))


def input_number() -> float:
    while True:
        try:
            number = input("Enter your number: ")
            return float(number)
        except ValueError:
            print("Invalid input. Try again.\n")


def input_numbers() -> list:
    numbers = []
    ask_input = True
    while ask_input:
        number = input_number()
        if number == -1:
            ask_input = False

        else:
            numbers.append(number)
    return numbers


def average(numbers: list) -> float:
    return sum(numbers) / len(numbers)


def how_many_positive(numbers: list) -> int:
    return len([number > 0 for number in numbers])


def print_stats(numbers: list) -> None:
    numbers_average = average(numbers)
    positives_count = how_many_positive(numbers)
    sorted_numbers = sorted(numbers)
    print(f"The numbers' average: {numbers_average}")
    print(f"The number of positive numbers: {positives_count}")
    print(f"The numbers sorted from low to high: {sorted_numbers}")


def num_len(number: int) -> int:
    """
    Returns the number of digits in a given natural number.
    :param number:
    :return:
    """
    return int(math.log10(number)) + 1


def pythagorean_triplet_by_sum(sum: int) -> None:
    """
    Prints all pythagorean triplets that fulfill the following conditions:
    a + b + c = sum
    a < b < c
    :param sum:
    :return:
    """
    sum_range = range(1, sum + 1)
    for a in sum_range:
        for b in sum_range:
            if (sum ** 2) - 2 * (sum * (a + b) - a * b) == 0 and a < b:
                c = sum - a - b
                print(f"{a} < {b} < {c}")


def is_sorted_palindrome(word: str) -> bool:
    """
    Returns if the give word is a sorted palindrome.
    :param word:
    :return:
    """
    half_word = "".join(word[:len(word) // 2 + 1])
    return is_sorted(half_word) and is_palindrome(word)


def print_numbers_stats() -> None:
    """
    Gets a list of numbers from the user.
    Prints the average, how many positive numbers were given and the numbers sorted from lowest to highest.
    :return:
    """
    numbers = input_numbers()
    print_stats(numbers)
