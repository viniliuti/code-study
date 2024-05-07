"""Serializers for recipe APIs"""

from core.models import Ingredient, Recipe, Tag
from rest_framework import serializers


class IngredientSerializer(serializers.ModelSerializer):
    """Serializer for ingredients"""

    class Meta:
        model = Ingredient
        fields = ["id", "name"]
        ready_only_fields = ["id"]


class TagSerializer(serializers.ModelSerializer):
    """Serializer for tags"""

    class Meta:
        model = Tag
        fields = ["id", "name"]
        read_only_fields = ["id"]


class RecipeSerializer(serializers.ModelSerializer):
    """Serializer for recipes"""

    tags = TagSerializer(many=True, required=False)
    ingredients = IngredientSerializer(many=True, required=False)

    class Meta:
        model = Recipe
        fields = [
            "id",
            "title",
            "time_minutes",
            "price",
            "link",
            "tags",
            "ingredients",
        ]
        read_only_fields = ["id"]

    def _get_context_user(self):
        """Get authenticated user from context"""
        return self.context["request"].user

    def _get_or_create_tags(self, tags, recipe):
        """Handle getting or creating tags as needed"""
        for tag in tags:
            tag_obj, created = Tag.objects.get_or_create(
                user=self._get_context_user(),
                **tag,
            )

            recipe.tags.add(tag_obj)

    def _get_or_create_ingredients(self, ingredients, recipe):
        """Handle getting or creating ingredients"""
        for ingredient in ingredients:
            ingredient_obj, create = Ingredient.objects.get_or_create(
                user=self._get_context_user(),
                **ingredient,
            )

            recipe.ingredients.add(ingredient_obj)

    def create(self, validated_data):
        """Create a recipe"""
        tags = validated_data.pop("tags", [])
        ingredients = validated_data.pop("ingredients", [])

        recipe = Recipe.objects.create(**validated_data)

        self._get_or_create_tags(
            tags,
            recipe,
        )
        self._get_or_create_ingredients(
            ingredients,
            recipe,
        )

        return recipe

    def update(self, instance, validated_data):
        """Update recipe"""
        tags = validated_data.pop("tags", None)
        ingredients = validated_data.pop("ingredients", None)

        if tags is not None:
            instance.tags.clear()
            self._get_or_create_tags(
                tags,
                instance,
            )

        if ingredients is not None:
            instance.ingredients.clear()
            self._get_or_create_ingredients(
                ingredients,
                instance,
            )

        # fills all other values back again (? why )
        for attr, value in validated_data.items():
            setattr(instance, attr, value)

        instance.save()
        return instance


class RecipeDetailSerializer(RecipeSerializer):
    """Serializer for recipe details"""

    class Meta(RecipeSerializer.Meta):
        fields = RecipeSerializer.Meta.fields + [
            "description",
            "image",
        ]


class RecipeImageSerializer(serializers.ModelSerializer):
    """Serializer for uploading images to recipe"""

    class Meta:
        model = Recipe
        fields = ["id", "image"]
        read_only_fields = ["id"]
        extra_kwargs = {
            "image": {
                "required": "True",
            }
        }
