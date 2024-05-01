"""
Sample test
"""

from django.test import SimpleTestCase

from app import calc


class CalcTest(SimpleTestCase):
    def test_add_numbers(self):
        result = calc.add(5, 6)

        self.assertEqual(result, 11)

    def test_subtract_number(self):
        result = calc.subtract(10, 15)

        self.assertEqual(result, 5)
