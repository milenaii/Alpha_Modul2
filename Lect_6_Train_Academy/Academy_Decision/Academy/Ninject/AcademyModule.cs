using Academy.Commands.Contracts;
using Academy.Commands.Creating;
using Academy.Commands.Decorators;
using Academy.Commands.Listing;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Academy.Core.Contracts;
using Academy.Core.Providers;
using Academy.Core;
using Academy.Core.Factories;
using Academy.Commands.Adding;

namespace Academy.Ninject
{
    public class AcademyModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IParser>().To<CommandParser>();

            this.Bind<IAcademyFactory>().To<AcademyFactory>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IDatabase>().To<Database>().InSingletonScope();

            this.Bind<ICommand>().To<ListCoursesInSeasonCommand>().Named("ListCoursesInSeason");
            this.Bind<ICommand>().To<ListUsersCommand>().Named("ListUsers");
            this.Bind<ICommand>().To<ListUsersInSeasonCommand>().Named("ListUsersInSeason");

            this.Bind<ICommand>().To<AddStudentToCourseCommand>().Named("AddStudentToCourse");
            this.Bind<ICommand>().To<AddStudentToSeasonCommand>().Named("AddStudentToSeason");
            this.Bind<ICommand>().To<AddTrainerToSeasonCommand>().Named("AddTrainerToSeason");
            
            this.Bind<ICommand>().To<CreateCourseCommand>().Named("CreateCourseInternal");
            this.Bind<ICommand>().To<CreateCourseResultCommand>().Named("CreateCourseResultInternal");
            this.Bind<ICommand>().To<CreateLectureCommand>().Named("CreateLectureInternal");
            this.Bind<ICommand>().To<CreateSeasonCommand>().Named("CreateSeasonInternal");
            this.Bind<ICommand>().To<CreateStudentCommand>().Named("CreateStudentInternal");
            this.Bind<ICommand>().To<CreateTrainerCommand>().Named("CreateTrainerInternal");

            this.Bind<ICommand>()
                .To<LoggingCommandDecorator>()
                .Named("CreateCourse")
                .WithConstructorArgument(this.Kernel.Get<ICommand>("CreateCourseInternal"));
            this.Bind<ICommand>()
                .To<LoggingCommandDecorator>()
                .Named("CreateCourseResult")
                .WithConstructorArgument(this.Kernel.Get<ICommand>("CreateCourseResultInternal"));
            this.Bind<ICommand>()
                .To<LoggingCommandDecorator>()
                .Named("CreateLecture")
                .WithConstructorArgument(this.Kernel.Get<ICommand>("CreateLectureInternal"));
            this.Bind<ICommand>()
                .To<LoggingCommandDecorator>()
                .Named("CreateSeason")
                .WithConstructorArgument(this.Kernel.Get<ICommand>("CreateSeasonInternal"));
            this.Bind<ICommand>()
                .To<LoggingCommandDecorator>()
                .Named("CreateStudent")
                .WithConstructorArgument(this.Kernel.Get<ICommand>("CreateStudentInternal"));
            this.Bind<ICommand>()
                .To<LoggingCommandDecorator>()
                .Named("CreateTrainer")
                .WithConstructorArgument(this.Kernel.Get<ICommand>("CreateTrainerInternal"));
        }
    }
}