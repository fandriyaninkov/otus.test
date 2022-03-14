using System;
using Xunit;

namespace Otus.Learning.Tests;

public class QuadraticEquationTest
{
    /// <summary>
    /// Тест проверяет, что для уравнения x^2 + 1 = 0 - корней нет
    /// </summary>
    [Fact]
    public void QuadraticEquationSolve_NoRoots_Test()
    {
        // Arrange
        var a = 1;
        var b = 0;
        var c = 1;
        var quadratic = new QuadraticEquation();
        
        // Act
        var result = quadratic.Solve(a, b, c);
        
        // Assert
        Assert.Empty(result);
    }

    /// <summary>
    /// Тест проверяет, что для уравнения x^2 - 1 = 0, есть два корня(1, -1)
    /// </summary>
    [Fact]
    public void QuadraticEquationSolve_TwoRoots_Test()
    {
        // Arrange
        var a = 1;
        var b = 0;
        var c = -1;
        var quadratic = new QuadraticEquation();
        
        // Act
        var result = quadratic.Solve(a, b, c);
        
        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(2, result.Length);
        Assert.Equal(1, result[0]);
        Assert.Equal(-1, result[1]);
    }

    /// <summary>
    /// Тест проверяет, что уравнение вида x^2 + 2x + 1 = 0, имеет один корень (-1)
    /// </summary>
    [Fact]
    public void QuadraticEquationSolve_SingleRoot_Test()
    {
        // Arrange
        var a = 1;
        var b = 2;
        var c = 1;
        var quadratic = new QuadraticEquation();
        
        // Act
        var result = quadratic.Solve(a, b, c);
        
        // Assert
        Assert.NotEmpty(result);
        Assert.Single(result);
        Assert.Equal(-1, result[0]);
    }

    /// <summary>
    /// Тест, который проверяет, что коэффициент 'a' не может быть равен нулю. Результат: Исключение
    /// </summary>
    [Fact]
    public void QuadraticEquationSolve_ThrowExceptionIfAZero_Test()
    {
        // Arrange
        var a = 0;
        var b = 2;
        var c = 1;
        var quadratic = new QuadraticEquation();
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => quadratic.Solve(a, b, c));
    }

    /// <summary>
    /// Тест, который проверяет, что дескриминант находится в диапазоне от +epsilon до -epsilon
    /// </summary>
    [Fact]
    public void QuadraticEquationSolve_CompareCoefficientsLessEpsilon_Test()
    {
        // Arrange
        var a = 1;
        var b = 0.025;
        var c = 0.0001;
        var quadratic = new QuadraticEquation();
        
        
        //Act
        var result = quadratic.Solve(a, b, c);
        
        // Assert
        Assert.NotEmpty(result);
        Assert.Single(result);
        Assert.Equal(-0.0125, Math.Round(result[0], 5));
    }
    
    /// <summary>
    /// Тест, который проверяет некорректность коэффициентов
    /// </summary>
    [Fact]
    public void QuadraticEquationSolve_CoefficientsNan_Test()
    {
        // Arrange
        var a = double.NaN;
        var b = 3;
        var c = 2;
        var quadratic = new QuadraticEquation();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => quadratic.Solve(a, b, c));
    }
    
    /// <summary>
    /// Тест, который проверяет некорректность коэффициентов
    /// </summary>
    [Fact]
    public void QuadraticEquationSolve_CoefficientsNegativeInfinity_Test()
    {
        // Arrange
        var a = 1;
        var b = Double.NegativeInfinity;
        var c = 2;
        var quadratic = new QuadraticEquation();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => quadratic.Solve(a, b, c));
    }
    
    /// <summary>
    /// Тест, который проверяет некорректность коэффициентов
    /// </summary>
    [Fact]
    public void QuadraticEquationSolve_CoefficientsPositiveInfinity_Test()
    {
        // Arrange
        var a = 1;
        var b = 3;
        var c = Double.PositiveInfinity;
        var quadratic = new QuadraticEquation();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => quadratic.Solve(a, b, c));
    }
    
    /// <summary>
    /// Тест проверяет, является ли дискриминант вещественным числом
    /// </summary>
    [Fact]
    public void QuadraticEquationSolve_CoefficientsMaxValue_Test()
    {
        // Arrange
        var a = Double.MaxValue;
        var b = 3;
        var c = 5;
        var quadratic = new QuadraticEquation();

        // Act & Assert
        Assert.Throws<ArithmeticException>(() => quadratic.Solve(a, b, c));
    }
}